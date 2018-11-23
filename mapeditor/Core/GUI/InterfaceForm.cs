using LoESoft.MapEditor.Core.GUI.HUD;
using LoESoft.MapEditor.Core.Layer;
using LoESoft.MapEditor.Core.Util;
using Microsoft.Xna.Framework;
using System;
using System.Linq;
using System.Windows.Forms;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;

namespace LoESoft.MapEditor.Core.GUI
{
    public partial class InterfaceForm : Form
    {
        public InterfaceForm()
        {
            InitializeComponent();
        }

        public void UpdateInfo()
        {
            MapNameLabel.Text = $"Name: {MapEditor.ActualMapName}";
            MapSizeLabel.Text = $"Size: {(int)MapEditor.ActualMapSize} x {(int)MapEditor.ActualMapSize}";
            GridCheckBox.Checked = MapEditor.ShowGrid;
        }

        private void InterfaceForm_Load(object sender, EventArgs e)
        {
            App.Info("Loading interface...");

            PalleteComboBox.Items.AddRange(MapEditor.InteractiveObjects.Keys.OrderBy(group => group).ToArray());

            App.Info("Loading interface... OK!");
        }

        private void PalleteComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PalletePanel.Controls.Clear();

            var selecteditem = PalleteComboBox.SelectedItem as string;
            var interactiveobjects = MapEditor.InteractiveObjects[selecteditem];
            var image = MapEditor.Images[selecteditem];
            var images = Utils.CropSpritesheet(image);
            var maxWidth = image.Width / Utils.TILE_SIZE;
            var maxHeight = image.Height / Utils.TILE_SIZE;

            for (var x = 0; x < maxWidth; x++)
                for (var y = 0; y < maxHeight; y++)
                {
                    var interactiveobject = interactiveobjects.FirstOrDefault(sample => sample.TextureData.X == x && sample.TextureData.Y == y);

                    if (interactiveobject != null)
                    {
                        var spritepallete = new SpritePallete()
                        {
                            Location = new Point(3 + x * 39, 3 + y * 39),
                            Name = $"spritePallete[{x}, {y}]",
                            Size = new Size(33, 33),
                            TabIndex = 0,
                            Image = images[x, y],
                            InteractiveObject = interactiveobject
                        };
                        spritepallete.SetImage();

                        PalletePanel.Controls.Add(spritepallete);
                    }
                }
        }

        private void GridCheckBox_CheckedChanged(object sender, EventArgs e) => MapEditor.ShowGrid = GridCheckBox.Checked;

        private void CompressionCheckBox_CheckedChanged(object sender, EventArgs e) => MapEditor.Mapper.EnableCompression = CompressionCheckBox.Checked;

        private void NewButton_Click(object sender, EventArgs e)
        {
            MapEditor.MapState = MapState.Inactive;

            var newmap = new NewMapForm();
            newmap.ShowDialog();

            if (newmap.DialogResult == DialogResult.OK)
            {
                App.Info("Creating new map...");

                MapEditor.Map = new Map(newmap.MapSize);
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