using LoESoft.MapEditor.Core.Layer;
using LoESoft.MapEditor.Core.Util;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;

namespace LoESoft.MapEditor.Core.GUI.HUD
{
    public partial class HUD : UserControl
    {
        private PalleteChangedDelegate OnPalleteChange;

        private delegate void PalleteChangedDelegate(object[] items);

        public HUD()
        {
            OnPalleteChange += (items) => UpdatePalleteComboBox(items);

            InitializeComponent();
        }

        public void UpdateInfo(int fps, string objectName = null)
        {
            MapNameLabel.Text = $"Name: {MEGameControl.ActualMapName}";
            MapSizeLabel.Text = $"Size: {(int)MEGameControl.ActualMapSize} x {(int)MEGameControl.ActualMapSize}";
            MapFPSLabel.Text = $"FPS: {fps}";
            MapObjectLabel.Text = $"Object: {objectName ?? "-"}";
            GridCheckBox.Checked = MEGameControl.ShowGrid;
        }

        public void UpdatePalleteComboBox(object[] items)
        {
            if (PalleteComboBox.InvokeRequired)
                Invoke(OnPalleteChange, items);
            else
                PalleteComboBox.Items.AddRange(items);
        }

        private void PalleteComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PalletePanel.Controls.Clear();

            var selecteditem = PalleteComboBox.SelectedItem as string;

            try
            {
                var interactiveobjects = MEGameControl.InteractiveObjects[selecteditem].OrderBy(interactiveobject => interactiveobject.Name);
                var image = MEGameControl.Images[selecteditem];
                var images = Utils.CropSpritesheet(image);
                var maxWidth = image.Width / Utils.TILE_SIZE;
                var maxHeight = image.Height / Utils.TILE_SIZE;

                var columns = new List<int>() { 2, 40, 78, 116, 154 };
                var row = 0;
                var column = 0;

                foreach (var interactiveobject in interactiveobjects)
                {
                    var spritepallete = new SpritePallete()
                    {
                        Location = new Point(1 + columns[column], 2 + row * 33),
                        Name = $"spritePallete[{row}, {column}]",
                        Size = new Size(33, 33),
                        TabIndex = 0,
                        Image = images[interactiveobject.TextureData.X, interactiveobject.TextureData.Y],
                        InteractiveObject = interactiveobject
                    };
                    spritepallete.SetImage();

                    PalletePanel.Controls.Add(spritepallete);

                    column++;

                    if (column == 5)
                    {
                        column = 0;
                        row++;
                    }
                }
            }
            catch (KeyNotFoundException) { App.Warn($"Spritesheet '{selecteditem}' was not found in collection."); }
        }

        private void GridCheckBox_CheckedChanged(object sender, EventArgs e) => MEGameControl.ShowGrid = GridCheckBox.Checked;

        private void CompressionCheckBox_CheckedChanged(object sender, EventArgs e) => MEGameControl.Mapper.EnableCompression = CompressionCheckBox.Checked;

        private void NewButton_Click(object sender, EventArgs e)
        {
            MEGameControl.MapState = MapState.Inactive;

            var newmap = new NewMapForm();
            newmap.ShowDialog();

            if (newmap.DialogResult == DialogResult.OK)
            {
                App.Info("Creating new map...");

                MEGameControl.Map = new Map(newmap.MapSize);
                MEGameControl.DrawOffset = Vector2.Zero;
                MEGameControl.ActualMapName = newmap.MapName;
                MEGameControl.ActualMapSize = newmap.MapSize;

                App.Info($"- Name: {newmap.MapName}");
                App.Info($"- Size: {(int)MEGameControl.ActualMapSize} x {(int)MEGameControl.ActualMapSize}");

                App.Info("Creating new map... OK!\n");
            }

            MEGameControl.MapState = MapState.Active;
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            MEGameControl.MapState = MapState.Inactive;

            var loadmap = new LoadMapForm();
            loadmap.ShowDialog();

            if (loadmap.DialogResult == DialogResult.OK)
            {
                App.Info($"Loading '{loadmap.MapName}' map...");

                MEGameControl.Map = loadmap.Map;
                MEGameControl.DrawOffset = Vector2.Zero;
                MEGameControl.ActualMapName = loadmap.MapName;
                MEGameControl.ActualMapSize = loadmap.Map.Size;

                App.Info($"- Name: {loadmap.MapName}");
                App.Info($"- Size: {(int)MEGameControl.ActualMapSize} x {(int)MEGameControl.ActualMapSize}");

                App.Info($"Loading '{loadmap.MapName}' map... OK!\n");
            }

            MEGameControl.MapState = MapState.Active;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            MEGameControl.MapState = MapState.Inactive;

            var savemap = new SaveMapForm(MEGameControl.ActualMapName);
            savemap.ShowDialog();

            if (savemap.DialogResult == DialogResult.OK)
                MessageBox.Show("Map saved!");

            MEGameControl.MapState = MapState.Active;
        }
    }
}