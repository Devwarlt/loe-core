using LoESoft.AssetsManager.Core.Assets;
using LoESoft.AssetsManager.Core.Assets.Structure;
using LoESoft.AssetsManager.Core.GUI.HUD;
using LoESoft.AssetsManager.Core.Structure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LoESoft.AssetsManager.Core.GUI
{
    public partial class Manager : Form
    {
        public string MainDir => Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public string BaseDir => App.Name;
        public string XmlDir => Path.Combine(MainDir, $"/{BaseDir}/xmls/");
        public string SpritesheetDir => Path.Combine(MainDir, $"/{BaseDir}/spritesheets/");

        private readonly Dictionary<string, string[]> HelpHints = new Dictionary<string, string[]>();

        public Manager()
        {
            InitializeComponent();

            App.Info("Loading embedded help hints...");

            LoadEmbeddedHelpHints();

            App.Info($"- Loaded {HelpHints.Keys.Count} help hint{(HelpHints.Keys.Count > 1 ? "s" : "")}.");
            App.Info("Loading embedded help hints... OK!");
            App.Info("Game Xml Manager is loading... OK!");
        }

        private void LoadEmbeddedHelpHints()
        {
            var assembly = Assembly.GetExecutingAssembly();

            foreach (var i in assembly.GetManifestResourceNames())
                if (i.Contains(".Help.") && i.Contains(".json"))
                    using (var stream = assembly.GetManifestResourceStream(i))
                        if (stream != null)
                            using (var memorystream = new MemoryStream())
                            {
                                stream.CopyTo(memorystream);

                                var buffer = memorystream.ToArray();
                                var data = Encoding.UTF8.GetString(buffer, 0, buffer.Length);

                                try
                                {
                                    var helphints = JsonConvert.DeserializeObject<List<HelpHint>>(data.Substring(1));

                                    foreach (var helphint in helphints)
                                        HelpHints.Add(helphint.Question, helphint.Answer);
                                }
                                catch (Exception e) { App.Warn($"\n- Resource: {i};\n- Data: {data}\n- Error:\n{e}"); }
                            }
        }

        private void Manager_Load(object sender, EventArgs e)
        {
            var i = 0;

            foreach (var helphint in HelpHints)
            {
                var hint = new HelpObject()
                {
                    Location = new Point(3, 3 + i * 99),
                    Name = $"hint{i}",
                    Size = new Size(750, 93),
                    TabIndex = 2,
                    Question = helphint.Key,
                    Answer = string.Join("\n", helphint.Value)
                };

                HelpTab.Controls.Add(hint);

                i++;
            };

            if (!Directory.Exists(MainDir))
                Directory.CreateDirectory(MainDir);

            if (!Directory.Exists(XmlDir))
                Directory.CreateDirectory(XmlDir);

            if (!Directory.Exists(SpritesheetDir))
                Directory.CreateDirectory(SpritesheetDir);
        }

        private void LoadAssetsButton_Click(object sender, EventArgs e)
        {
            LoadXmls();
            LoadSpritesheets();

            var i = 0;

            foreach (var xml in XmlLibrary.Xmls.OrderBy(name => name.Key))
            {
                var xmlobject = new XmlObject()
                {
                    Location = new Point(3, 3 + i * 42),
                    Name = $"xmlobject{i}",
                    Size = new Size(188, 36),
                    TabIndex = 2,
                    XmlContent = xml.Value.Value
                };
                xmlobject.SetFileName(xml.Key);
                xmlobject.SetFileSize(xml.Value.Key);
                xmlobject.Action = () =>
                {
                };

                XmlPanel.Controls.Add(xmlobject);

                i++;
            }

            i = 0;

            foreach (var spritesheet in SpriteLibrary.Spritesheets.OrderBy(name => name.Key))
            {
                var pngobject = new PngObject()
                {
                    Location = new Point(3, 3 + i * 42),
                    Name = $"pngobject{i}",
                    Size = new Size(188, 36),
                    TabIndex = 2
                };
                pngobject.SetFileName(spritesheet.Key);
                pngobject.SetFileSize(spritesheet.Value.Key);

                SpritesheetPanel.Controls.Add(pngobject);

                i++;
            }
        }

        private void LoadXmls()
        {
            App.Info($"Loading remote xmls...");

            var xmls = Directory.EnumerateFiles(XmlDir, "*.xml").Select(file =>
            {
                var fileparams = file.Split('/');
                var fileinfo = new FileInfo(file);

                using (var stream = File.OpenRead(file))
                    return new XmlFile()
                    {
                        File = fileparams[fileparams.Length - 1],
                        Size = GetFileSize(fileinfo.Length),
                        Path = fileinfo.FullName,
                        XElement = XElement.Load(stream)
                    };
            }).ToList();

            XmlLibrary.Init(xmls);

            XmlCountLabel.Text = xmls.Count.ToString();

            App.Info($"Loading remote xmls... OK!");
        }

        private void LoadSpritesheets()
        {
            App.Info($"Loading remote spritesheets...");

            var spritesheets = Directory.EnumerateFiles(SpritesheetDir, "*.png").Select(spritesheet =>
            {
                var fileparams = spritesheet.Split('/');
                var fileinfo = new FileInfo(spritesheet);

                return new SpritesheetFile()
                {
                    File = fileparams[fileparams.Length - 1],
                    Size = GetFileSize(fileinfo.Length),
                    Path = fileinfo.FullName,
                    Image = Image.FromFile(spritesheet)
                };
            }).ToList();

            SpritesheetCountLabel.Text = spritesheets.Count.ToString();

            SpriteLibrary.Init(spritesheets);

            App.Info($"Loading remote spritesheets... OK!");
        }

        private string GetFileSize(long size)
        {
            if (size < 1024)
                return size + " B";
            else if (size >= 1024 && size < 1024 * 1024)
                return size / 1024 + " KB";
            else if (size >= 1024 * 1024 && size < 1024 * 1024 * 1024)
                return size / (1024 * 1024) + " MB";
            else
                return size / (1024 * 1024 * 1024) + " GB";
        }
    }
}