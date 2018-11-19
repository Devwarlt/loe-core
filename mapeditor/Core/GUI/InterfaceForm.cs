using LoESoft.MapEditor.Core.Assets;
using LoESoft.MapEditor.Core.Assets.Structure;
using LoESoft.MapEditor.Core.Assets.Structure.Exclusive;
using LoESoft.MapEditor.Core.GUI.HUD;
using LoESoft.MapEditor.Core.Layer;
using LoESoft.MapEditor.Core.Util;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;

namespace LoESoft.MapEditor.Core.GUI
{
    public partial class InterfaceForm : Form
    {
        private Dictionary<string, SpriteItem[,]> _spriteAssets { get; set; }
        private Dictionary<int, InteractiveObject> _interactiveObjects { get; set; }
        private Dictionary<int, TextureData> _itemDatas { get; set; }
        private Dictionary<int, TextureData> _objectDatas { get; set; }
        private Dictionary<int, TextureData> _tileDatas { get; set; }

        public InterfaceForm()
        {
            App.Info("Loading interface...");

            _spriteAssets = new Dictionary<string, SpriteItem[,]>();
            _interactiveObjects = new Dictionary<int, InteractiveObject>();
            _itemDatas = new Dictionary<int, TextureData>();
            _objectDatas = new Dictionary<int, TextureData>();
            _tileDatas = new Dictionary<int, TextureData>();

            InitializeComponent();
        }

        public void UpdateInfo()
        {
            MapLabel.Text = $"Map: {MapEditor.ActualMapName}";
            SizeLabel.Text = $"Size: {(int)MapEditor.ActualMapSize} x {(int)MapEditor.ActualMapSize}";
            LayerLabel.Text = $"Layer: [{(int)MapEditor.CurrentLayer}] {MapEditor.CurrentLayer}";
            GridCheckBox.Checked = MapEditor.ShowGrid;
        }

        private void InterfaceForm_Load(object sender, EventArgs e)
        {
            var groups = new List<string>();

            // load items
            foreach (var xml in XmlLibrary.ItemsXml.Values)
            {
                if (!groups.Contains(xml.LayerData.Group))
                    groups.Add(xml.LayerData.Group);

                if (!_spriteAssets.Keys.Contains(xml.TextureData.File))
                    AddSpritesheet(xml.TextureData.File);

                AddInteractiveObject(xml);

                _itemDatas.Add(xml.Id, xml.TextureData);
            }

            // load objects
            foreach (var xml in XmlLibrary.ObjectsXml.Values)
            {
                if (!groups.Contains(xml.LayerData.Group))
                    groups.Add(xml.LayerData.Group);

                if (!_spriteAssets.Keys.Contains(xml.TextureData.File))
                    AddSpritesheet(xml.TextureData.File);

                AddInteractiveObject(xml);
            }

            // load tiles
            foreach (var xml in XmlLibrary.TilesXml.Values)
            {
                if (!groups.Contains(xml.LayerData.Group))
                    groups.Add(xml.LayerData.Group);

                if (!_spriteAssets.Keys.Contains(xml.TextureData.File))
                    AddSpritesheet(xml.TextureData.File);

                AddInteractiveObject(xml);
            }

            PalleteComboBox.Items.AddRange(groups.OrderBy(group => group).ToArray());

            App.Info("Loading sprite assets...");

            foreach (var spriteasset in _spriteAssets)
                App.Info($"- Group '{spriteasset.Key}': {spriteasset.Value.Length} sprite{(spriteasset.Value.Length > 1 ? "s" : "")}");

            App.Info("Loading sprite assets... OK!");
            App.Info("Loading interface... OK!");
        }

        private void AddSpritesheet(string file)
        {
            var sprites = Utils.LoadEmbeddedSpritesheetToImage(file);

            _spriteAssets.Add(sprites.Key, Utils.CropSpritesheet(sprites.Value));
        }

        private void AddInteractiveObject(XmlContent xml)
            => _interactiveObjects.Add(xml.Id, new InteractiveObject()
            {
                Id = xml.Id,
                Type = xml.Type,
                Name = xml.Name,
                LayerData = xml.LayerData,
                TextureData = xml.TextureData
            });

        private void PalleteComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PalletePanel.Controls.Clear();

            var currentspritesheet = _spriteAssets[PalleteComboBox.SelectedItem.ToString()];

            var spriteitems = _spriteAssets[PalleteComboBox.SelectedItem.ToString()];

            for (var x = 0; x < spriteitems[0, 0].MaximumX; x++)
                for (var y = 0; y < spriteitems[0, 0].MaximumY; y++)
                {
                    var spritepallete = new SpritePallete()
                    {
                        Location = new Point(3 + x * 39, 3 + y * 39),
                        Name = $"spritePallete[{x}, {y}]",
                        Size = new Size(33, 33),
                        TabIndex = 0,
                        SpriteItem = spriteitems[x, y]
                    };
                    spritepallete.SetImage();

                    PalletePanel.Controls.Add(spritepallete);
                }
        }

        private void GridCheckBox_CheckedChanged(object sender, EventArgs e) => MapEditor.ShowGrid = GridCheckBox.Checked;

        private void NewButton_Click(object sender, EventArgs e)
        {
            MapEditor.MapState = MapState.Inactive;

            var newmap = new NewMapForm();
            newmap.ShowDialog();

            if (newmap.DialogResult == DialogResult.OK)
            {
                App.Info("Creating new map...");

                MapEditor.Map = new Map(newmap.MapSize);
                MapEditor.CurrentLayer = MapLayer.UNDERGROUND;
                MapEditor.CurrentIndex = 0;
                MapEditor.DrawOffset = Vector2.Zero;
                MapEditor.ActualMapName = newmap.MapName;
                MapEditor.ActualMapSize = newmap.MapSize;

                App.Info($"- Name: {newmap.MapName}");
                App.Info($"- Size: {(int)MapEditor.ActualMapSize} x {(int)MapEditor.ActualMapSize}");

                App.Info("Creating new map... OK!\n");
            }

            MapEditor.MapState = MapState.Active;
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            MapEditor.MapState = MapState.Inactive;

            var loadmap = new LoadMapForm();
            loadmap.ShowDialog();

            if (loadmap.DialogResult == DialogResult.OK)
            {
                App.Info($"Loading '{loadmap.MapName}' map...");

                MapEditor.Map = loadmap.Map;
                MapEditor.CurrentLayer = MapLayer.UNDERGROUND;
                MapEditor.CurrentIndex = 0;
                MapEditor.DrawOffset = Vector2.Zero;
                MapEditor.ActualMapName = loadmap.MapName;
                MapEditor.ActualMapSize = loadmap.Map.Size;

                App.Info($"- Name: {loadmap.MapName}");
                App.Info($"- Size: {(int)MapEditor.ActualMapSize} x {(int)MapEditor.ActualMapSize}");

                App.Info($"Loading '{loadmap.MapName}' map... OK!\n");
            }

            MapEditor.MapState = MapState.Active;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            MapEditor.MapState = MapState.Inactive;

            var savemap = new SaveMapForm(MapEditor.ActualMapName);
            savemap.ShowDialog();

            if (savemap.DialogResult == DialogResult.OK)
                MessageBox.Show("Map saved!");

            MapEditor.MapState = MapState.Active;
        }
    }
}