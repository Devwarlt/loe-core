using LoESoft.AssetsManager.Core.Assets;
using LoESoft.AssetsManager.Core.Assets.Structure;
using LoESoft.AssetsManager.Core.GUI.HUD;
using LoESoft.AssetsManager.Core.Structure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;
using static LoESoft.AssetsManager.Core.Assets.Structure.XmlContent;

namespace LoESoft.AssetsManager.Core.GUI
{
    public partial class Manager : Form
    {
        public static Dictionary<string, Image[,]> Spritesheets { get; set; }
        public static Dictionary<string, List<ObjectsContent>> XmlObjects { get; set; }
        public static Dictionary<string, List<ItemsContent>> XmlItems { get; set; }
        public static Dictionary<string, List<TilesContent>> XmlTiles { get; set; }

        public string MainDir => Path.GetPathRoot(Environment.SystemDirectory);
        public string BaseDir => Path.Combine(MainDir, App.Name);
        public string XmlDir => Path.Combine(BaseDir, "Xmls");
        public string SpritesheetDir => Path.Combine(BaseDir, "Spritesheets");

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

        private void FolderIcon_Click(object sender, EventArgs e) => Process.Start($"{Path.Combine(BaseDir)}");

        private void LoadAssetsButton_Click(object sender, EventArgs e)
        {
            XmlObjects = new Dictionary<string, List<ObjectsContent>>();
            XmlItems = new Dictionary<string, List<ItemsContent>>();
            XmlTiles = new Dictionary<string, List<TilesContent>>();
            Spritesheets = new Dictionary<string, Image[,]>();

            LoadXmls();
            LoadSpritesheets();

            var i = 0;

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

                Spritesheets.Add(spritesheet.Key, CropSpritesheet(spritesheet.Value.Value));

                i++;
            }

            i = 0;

            MainTab.Controls.Remove(XmlPanel);

            XmlPanel = new Panel()
            {
                AutoScroll = true,
                BackColor = SystemColors.Info,
                BorderStyle = BorderStyle.Fixed3D,
                Location = new Point(550, 156),
                Name = "XmlPanel",
                Size = new Size(220, 160),
                TabIndex = 1
            };

            MainTab.Controls.Add(XmlPanel);

            foreach (var xml in XmlLibrary.Xmls.OrderBy(name => name.Key))
            {
                var objects = new List<ObjectsContent>();
                var items = new List<ItemsContent>();
                var tiles = new List<TilesContent>();
                var name = xml.Key;
                var xmlcontent = xml.Value.Value;

                foreach (var elem in xmlcontent.XPathSelectElements("//Object"))
                {
                    switch ((ContentType)int.Parse(elem.Attribute("type").Value))
                    {
                        case ContentType.Objects: objects.Add(new ObjectsContent(elem)); break;
                        case ContentType.Items: items.Add(new ItemsContent(elem)); break;
                        case ContentType.Tiles: tiles.Add(new TilesContent(elem)); break;
                    }
                }

                XmlObjects.Add(name, objects);
                XmlItems.Add(name, items);
                XmlTiles.Add(name, tiles);

                var xobjects = XmlObjects[name];
                var xitems = XmlItems[name];
                var xtiles = XmlTiles[name];
                var palletes = new List<KeyValuePair<int, SpritePallete>>();
                var columns = new List<int>() { 4, 43, 82, 121, 160, 199 };
                var row = 0;
                var column = 0;

                foreach (var xobject in xobjects)
                {
                    var xobjectpallete = new SpritePallete()
                    {
                        Name = xobject.Name,
                        Size = new Size(33, 33),
                        TabIndex = 2
                    };
                    xobjectpallete.SetImage(Spritesheets[xobject.TextureData.File][xobject.TextureData.X, xobject.TextureData.Y]);

                    palletes.Add(new KeyValuePair<int, SpritePallete>(xobject.Id, xobjectpallete));
                }

                foreach (var xitem in xitems)
                {
                    var xitempallete = new SpritePallete()
                    {
                        Name = xitem.Name,
                        Size = new Size(33, 33),
                        TabIndex = 2
                    };
                    xitempallete.SetImage(Spritesheets[xitem.TextureData.File][xitem.TextureData.X, xitem.TextureData.Y]);

                    palletes.Add(new KeyValuePair<int, SpritePallete>(xitem.Id, xitempallete));
                }

                foreach (var xtile in xtiles)
                {
                    var xtilepallete = new SpritePallete()
                    {
                        Name = xtile.Name,
                        Size = new Size(33, 33),
                        TabIndex = 2
                    };
                    xtilepallete.SetImage(Spritesheets[xtile.TextureData.File][xtile.TextureData.X, xtile.TextureData.Y]);

                    palletes.Add(new KeyValuePair<int, SpritePallete>(xtile.Id, xtilepallete));
                }

                foreach (var pallete in palletes.OrderBy(id => id.Key))
                {
                    var sampleobject = xobjects.FirstOrDefault(sample => sample.Id == pallete.Key);
                    var sampleitem = xitems.FirstOrDefault(sample => sample.Id == pallete.Key);
                    var sampletile = xtiles.FirstOrDefault(sample => sample.Id == pallete.Key);

                    ItemControl itemcontrol = null;

                    if (sampleobject != null)
                        itemcontrol = new ItemControl(pallete.Value, xml.Key, sampleobject)
                        {
                            Location = new Point(0, 0),
                            Name = "itemControl1",
                            Size = new Size(295, 534),
                            TabIndex = 2
                        };

                    if (sampleitem != null)
                        itemcontrol = new ItemControl(pallete.Value, xml.Key, sampleitem)
                        {
                            Location = new Point(0, 0),
                            Name = "itemControl1",
                            Size = new Size(295, 534),
                            TabIndex = 2
                        };

                    if (sampletile != null)
                        itemcontrol = new ItemControl(pallete.Value, xml.Key, sampletile)
                        {
                            Location = new Point(0, 0),
                            Name = "itemControl1",
                            Size = new Size(295, 534),
                            TabIndex = 2
                        };

                    pallete.Value.Location = new Point(columns[column], 3 + row * 39);
                    pallete.Value.ItemControl = itemcontrol;
                    pallete.Value.Action = () =>
                    {
                        SplitPanels.Panel2.Controls.Clear();

                        if (pallete.Value.ItemControl != null)
                            SplitPanels.Panel2.Controls.Add(pallete.Value.ItemControl);
                    };

                    column++;

                    if (column == columns.Count)
                    {
                        column = 0;
                        row++;
                    }
                }

                var xmlobject = new XmlObject()
                {
                    Location = new Point(3, 3 + i * 42),
                    Name = "xmlobject",
                    Size = new Size(188, 36),
                    TabIndex = 2,
                    Id = i,
                    XmlContent = xml.Value.Value,
                    FileName = xml.Key,
                    FileSize = xml.Value.Key,
                    Palletes = palletes.OrderBy(id => id.Key).Select(pallete => pallete.Value).ToList()
                };
                xmlobject.Action = () =>
                {
                    SplitPanels.Panel1.Controls.Clear();

                    foreach (var pallete in xmlobject.Palletes)
                        SplitPanels.Panel1.Controls.Add(pallete);

                    WorkingTitleLabel.Text = "Working on...";
                    WorkingContentLabel.Text = xml.Key;
                };

                XmlPanel.Controls.Add(xmlobject);

                i++;
            }
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

        private void LoadXmls()
        {
            App.Info($"Loading remote xmls...");

            var xmls = Directory.EnumerateFiles(XmlDir, "*.xml").Select(file =>
            {
                var fileinfo = new FileInfo(file);

                using (var stream = File.OpenRead(file))
                    return new XmlFile()
                    {
                        File = Path.GetFileNameWithoutExtension(fileinfo.Name),
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
                var fileinfo = new FileInfo(spritesheet);

                return new SpritesheetFile()
                {
                    File = Path.GetFileNameWithoutExtension(fileinfo.Name),
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

        private static Image[,] CropSpritesheet(Image image)
        {
            try
            {
                var width = image.Width / 16;
                var height = image.Height / 16;
                var spriteitems = new Image[width, height];

                for (var x = 0; x < width; x++)
                    for (var y = 0; y < height; y++)
                    {
                        spriteitems[x, y] = new Bitmap(16, 16);

                        var graphics = Graphics.FromImage(spriteitems[x, y]);
                        graphics.DrawImage(image, new Rectangle(0, 0, 16, 16), new Rectangle(x * 16, y * 16, 16, 16), GraphicsUnit.Pixel);
                        graphics.Dispose();
                    }

                return spriteitems;
            }
            catch (Exception e) { App.Error(e); }

            return null;
        }

        public void RemoveItemFromXmlPanel(int id)
        {
            var xmlobjects = new List<XmlObject>();
            var i = 0;
            var target = string.Empty;

            foreach (var xmlobject in Array.ConvertAll(XmlPanel.Controls.Find("xmlobject", true), xmlobject => (XmlObject)xmlobject))
            {
                if (xmlobject.Id != id)
                {
                    xmlobjects.Add(new XmlObject()
                    {
                        Location = new Point(3, 3 + i * 42),
                        Name = "xmlobject",
                        Size = new Size(188, 36),
                        TabIndex = 2,
                        Id = xmlobject.Id,
                        XmlContent = xmlobject.XmlContent,
                        FileName = xmlobject.FileName,
                        FileSize = xmlobject.FileSize,
                        Palletes = xmlobject.Palletes
                    });

                    i++;
                }
                else
                    target = xmlobject.FileName;
            }

            MainTab.Controls.Remove(XmlPanel);

            XmlPanel = new Panel()
            {
                AutoScroll = true,
                BackColor = SystemColors.Info,
                BorderStyle = BorderStyle.Fixed3D,
                Location = new Point(550, 156),
                Name = "XmlPanel",
                Size = new Size(220, 160),
                TabIndex = 1
            };

            MainTab.Controls.Add(XmlPanel);

            foreach (var xmlobject in xmlobjects)
                XmlPanel.Controls.Add(xmlobject);

            XmlCountLabel.Text = XmlPanel.Controls.Count.ToString();

            XmlLibrary.Xmls.Remove(target);
        }
    }
}