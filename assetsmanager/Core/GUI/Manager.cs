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
        public static Dictionary<string, SpritesContent> Spritesheets { get; set; }
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

            AddButton.Image = Properties.Resources.hud_plus_inactive;
            AddButton.Enabled = false;
            SaveButton.Image = Properties.Resources.hud_save_inactive;
            SaveButton.Enabled = false;
        }

        private void LoadAssetsButton_Click(object sender, EventArgs e)
        {
            WorkingTitleLabel.Text = string.Empty;
            WorkingContentLabel.Text = string.Empty;

            XmlObjects = new Dictionary<string, List<ObjectsContent>>();
            XmlItems = new Dictionary<string, List<ItemsContent>>();
            XmlTiles = new Dictionary<string, List<TilesContent>>();
            Spritesheets = new Dictionary<string, SpritesContent>();

            LoadXmls();
            LoadSpritesheets();

            foreach (var spritesheet in SpriteLibrary.Spritesheets)
                Spritesheets.Add(spritesheet.Key, CropSpritesheet(spritesheet.Value.Value));

            RefreshXmls();

            AddButton.Image = Properties.Resources.hud_plus;
            AddButton.Enabled = true;
            SaveButton.Image = Properties.Resources.hud_save;
            SaveButton.Enabled = true;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var addform = new AddForm() { Manager = this };
            addform.ShowDialog();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            foreach (var removedfile in XmlLibrary.RemovedXmls)
            {
                var oldpath = Path.Combine(XmlDir, $"{removedfile}.xml");
                var newpath = Path.Combine(XmlDir, $"[DELETED] {removedfile}.xml");

                File.Move(oldpath, newpath);
            }

            var xmls = new Dictionary<string, List<XDocument>>();

            foreach (var xml in XmlLibrary.Xmls)
                xmls.Add(xml.Key, new List<XDocument>());

            foreach (var xmlobject in XmlObjects)
            {
                XDocument xmlobjects = null;

                foreach (var objectscontent in xmlobject.Value)
                    ;

                if (xmlobjects != null)
                    xmls[xmlobject.Key].Add(xmlobjects);
            }
        }

        private void FolderButton_Click(object sender, EventArgs e) => Process.Start($"{Path.Combine(BaseDir)}");

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

            var xmls = Directory.EnumerateFiles(XmlDir, "*.xml").Where(name => !name.Contains("[DELETED]")).Select(file =>
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

        private static SpritesContent CropSpritesheet(Image image)
        {
            try
            {
                var width = image.Width / 16;
                var height = image.Height / 16;
                var spritecontent = new SpritesContent()
                {
                    Width = width,
                    Height = height,
                    Image = new Image[width, height]
                };

                for (var x = 0; x < width; x++)
                    for (var y = 0; y < height; y++)
                    {
                        spritecontent.Image[x, y] = new Bitmap(16, 16);

                        var graphics = Graphics.FromImage(spritecontent.Image[x, y]);
                        graphics.DrawImage(image, new Rectangle(0, 0, 16, 16), new Rectangle(x * 16, y * 16, 16, 16), GraphicsUnit.Pixel);
                        graphics.Dispose();
                    }

                return spritecontent;
            }
            catch (Exception e) { App.Error(e); }

            return null;
        }

        public void RemoveFromXml(int parentId, int id)
        {
            var palletes = new List<SpritePallete>();
            var columns = new List<int>() { 4, 43, 82, 121, 160, 199 };
            var row = 0;
            var column = 0;
            var target = new KeyValuePair<string, ContentType>();

            foreach (var pallete in Array.ConvertAll(SplitPanels.Panel1.Controls.Find("spritepallete", true), pallete => (SpritePallete)pallete))
            {
                if (pallete.Id != id)
                {
                    var newpallete = new SpritePallete()
                    {
                        Origin = pallete.Origin,
                        Type = pallete.Type,
                        Id = pallete.Id,
                        Name = "spritepallete",
                        Size = new Size(33, 33),
                        TabIndex = 2,
                        Image = pallete.Image
                    };

                    var sampleobject = pallete.ItemControl.ObjectsContent;
                    var sampleitem = pallete.ItemControl.ItemsContent;
                    var sampletile = pallete.ItemControl.TilesContent;

                    if (sampleobject != null)
                        newpallete.ItemControl = new ItemControl(newpallete, newpallete.Origin, sampleobject);

                    if (sampleitem != null)
                        newpallete.ItemControl = new ItemControl(newpallete, newpallete.Origin, sampleobject);

                    if (sampletile != null)
                        newpallete.ItemControl = new ItemControl(newpallete, newpallete.Origin, sampletile);

                    newpallete.ItemControl.Location = new Point(0, 0);
                    newpallete.ItemControl.Name = "itemcontrol";
                    newpallete.ItemControl.Size = new Size(295, 534);
                    newpallete.ItemControl.TabIndex = 2;

                    pallete.ItemControl.Dispose();
                    pallete.Dispose();

                    palletes.Add(newpallete);
                }
                else
                    target = new KeyValuePair<string, ContentType>(pallete.Origin, pallete.Type);
            }

            SplitPanels.Panel1.Controls.Clear();
            SplitPanels.Panel2.Controls.Clear();

            foreach (var pallete in palletes.OrderBy(i => i.Id))
            {
                pallete.Location = new Point(columns[column], 3 + row * 39);
                pallete.Action = () =>
                {
                    SplitPanels.Panel2.Controls.Clear();

                    if (pallete.ItemControl != null)
                        SplitPanels.Panel2.Controls.Add(pallete.ItemControl);
                };

                SplitPanels.Panel1.Controls.Add(pallete);

                column++;

                if (column == columns.Count)
                {
                    column = 0;
                    row++;
                }
            }

            try
            {
                switch (target.Value)
                {
                    case ContentType.Objects: XmlObjects[target.Key].RemoveAt(XmlObjects[target.Key].FindIndex(xobject => xobject.Id == id)); break;
                    case ContentType.Items: XmlItems[target.Key].RemoveAt(XmlItems[target.Key].FindIndex(xitem => xitem.Id == id)); break;
                    case ContentType.Tiles: XmlTiles[target.Key].RemoveAt(XmlTiles[target.Key].FindIndex(xtile => xtile.Id == id)); break;
                }
            }
            catch (Exception e) { App.Warn($"An error occurred along SpritePallete remotion:\n{e}"); }

            foreach (var xmlobject in Array.ConvertAll(XmlPanel.Controls.Find("xmlobject", true), xmlobject => (XmlObject)xmlobject))
                if (xmlobject.Id == parentId)
                {
                    xmlobject.Palletes = palletes;
                    xmlobject.Action = () =>
                    {
                        SplitPanels.Panel1.Controls.Clear();

                        foreach (var pallete in xmlobject.Palletes)
                        {
                            pallete.ParentId = xmlobject.Id;

                            SplitPanels.Panel1.Controls.Add(pallete);
                        }

                        WorkingTitleLabel.Text = "Working on...";
                        WorkingContentLabel.Text = target.Key;
                    };
                    break;
                }
        }

        public void AddOrRemoveXml(int id, string name = null)
        {
            SplitPanels.Panel1.Controls.Clear();
            SplitPanels.Panel2.Controls.Clear();

            var xmlobjects = new List<XmlObject>();
            var i = 0;
            var target = string.Empty;

            foreach (var xmlobject in Array.ConvertAll(XmlPanel.Controls.Find("xmlobject", true), xmlobject => (XmlObject)xmlobject))
            {
                if (xmlobject.Id != id)
                {
                    var newxmlobject = new XmlObject()
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
                    };
                    newxmlobject.Action = () =>
                    {
                        SplitPanels.Panel1.Controls.Clear();

                        foreach (var pallete in newxmlobject.Palletes)
                        {
                            pallete.ParentId = newxmlobject.Id;

                            SplitPanels.Panel1.Controls.Add(pallete);
                        }

                        WorkingTitleLabel.Text = "Working on...";
                        WorkingContentLabel.Text = newxmlobject.FileName;
                    };
                    xmlobjects.Add(newxmlobject);

                    i++;
                }
                else
                    target = xmlobject.FileName;
            }

            if (name != null)
            {
                var xmlobject = new XmlObject()
                {
                    Location = new Point(3, 3 + i * 42),
                    Name = "xmlobject",
                    Size = new Size(188, 36),
                    TabIndex = 2,
                    Id = i,
                    XmlContent = null,
                    FileName = name,
                    FileSize = "<new>",
                    Palletes = new List<SpritePallete>()
                };
                xmlobject.Action = () =>
                {
                    SplitPanels.Panel1.Controls.Clear();

                    WorkingTitleLabel.Text = string.Empty;
                    WorkingContentLabel.Text = "This XML document is empty!";
                };

                xmlobjects.Add(xmlobject);
            }

            MainTab.Controls.Remove(XmlPanel);

            XmlPanel = new Panel()
            {
                AutoScroll = true,
                BackColor = SystemColors.Info,
                BorderStyle = BorderStyle.Fixed3D,
                Location = new Point(550, 202),
                Name = "XmlPanel",
                Size = new Size(220, 335),
                TabIndex = 1
            };

            MainTab.Controls.Add(XmlPanel);

            i = 0;

            foreach (var xmlobject in xmlobjects.OrderBy(xml => xml.FileName))
            {
                xmlobject.Location = new Point(3, 3 + i * 42);

                XmlPanel.Controls.Add(xmlobject);

                i++;
            }

            WorkingTitleLabel.Text = string.Empty;
            WorkingContentLabel.Text = string.Empty;
            XmlCountLabel.Text = XmlPanel.Controls.Count.ToString();

            if (target != string.Empty)
            {
                XmlLibrary.RemovedXmls.Add(target);
                XmlLibrary.Xmls.Remove(target);
            }
        }

        public void RefreshXmls()
        {
            SplitPanels.Panel1.Controls.Clear();
            SplitPanels.Panel2.Controls.Clear();

            var i = 0;

            MainTab.Controls.Remove(XmlPanel);

            XmlPanel = new Panel()
            {
                AutoScroll = true,
                BackColor = SystemColors.Info,
                BorderStyle = BorderStyle.Fixed3D,
                Location = new Point(550, 202),
                Name = "XmlPanel",
                Size = new Size(220, 335),
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

                if (!XmlObjects.ContainsKey(name))
                    XmlObjects.Add(name, objects);
                if (!XmlItems.ContainsKey(name))
                    XmlItems.Add(name, items);
                if (!XmlTiles.ContainsKey(name))
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
                        Origin = name,
                        Type = ContentType.Objects,
                        Id = xobject.Id,
                        Name = "spritepallete",
                        Size = new Size(33, 33),
                        TabIndex = 2,
                        Image = Spritesheets[xobject.TextureData.File].Image[xobject.TextureData.X, xobject.TextureData.Y]
                    };

                    palletes.Add(new KeyValuePair<int, SpritePallete>(xobject.Id, xobjectpallete));
                }

                foreach (var xitem in xitems)
                {
                    var xitempallete = new SpritePallete()
                    {
                        Origin = name,
                        Type = ContentType.Items,
                        Id = xitem.Id,
                        Name = "spritepallete",
                        Size = new Size(33, 33),
                        TabIndex = 2,
                        Image = Spritesheets[xitem.TextureData.File].Image[xitem.TextureData.X, xitem.TextureData.Y]
                    };

                    palletes.Add(new KeyValuePair<int, SpritePallete>(xitem.Id, xitempallete));
                }

                foreach (var xtile in xtiles)
                {
                    var xtilepallete = new SpritePallete()
                    {
                        Origin = name,
                        Type = ContentType.Tiles,
                        Id = xtile.Id,
                        Name = "spritepallete",
                        Size = new Size(33, 33),
                        TabIndex = 2,
                        Image = Spritesheets[xtile.TextureData.File].Image[xtile.TextureData.X, xtile.TextureData.Y]
                    };

                    palletes.Add(new KeyValuePair<int, SpritePallete>(xtile.Id, xtilepallete));
                }

                foreach (var pallete in palletes.OrderBy(id => id.Key))
                {
                    var sampleobject = xobjects.FirstOrDefault(sample => sample.Id == pallete.Key);
                    var sampleitem = xitems.FirstOrDefault(sample => sample.Id == pallete.Key);
                    var sampletile = xtiles.FirstOrDefault(sample => sample.Id == pallete.Key);

                    ItemControl itemcontrol = null;

                    if (sampleobject != null)
                        itemcontrol = new ItemControl(pallete.Value, name, sampleobject);

                    if (sampleitem != null)
                        itemcontrol = new ItemControl(pallete.Value, name, sampleitem);

                    if (sampletile != null)
                        itemcontrol = new ItemControl(pallete.Value, name, sampletile);

                    itemcontrol.Location = new Point(0, 0);
                    itemcontrol.Name = "itemcontrol";
                    itemcontrol.Size = new Size(295, 534);
                    itemcontrol.TabIndex = 2;

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
                    {
                        pallete.ParentId = xmlobject.Id;

                        SplitPanels.Panel1.Controls.Add(pallete);
                    }

                    WorkingTitleLabel.Text = "Working on...";
                    WorkingContentLabel.Text = xml.Key;
                };

                XmlPanel.Controls.Add(xmlobject);

                i++;
            }
        }
    }
}