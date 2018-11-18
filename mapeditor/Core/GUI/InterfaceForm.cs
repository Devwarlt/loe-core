﻿using LoESoft.MapEditor.Core.Layer;
using Microsoft.Xna.Framework;
using System;
using System.Windows.Forms;

namespace LoESoft.MapEditor.Core.GUI
{
    public partial class InterfaceForm : Form
    {
        public InterfaceForm() => InitializeComponent();

        public void UpdateInfo()
        {
            MapLabel.Text = $"Map: {MapEditor.ActualMapName}";

            var size = MapEditor.ActualMapSize.ToString().Replace("SIZE_", "");
            SizeLabel.Text = $"Size: {size} x {size}";
            LayerLabel.Text = $"Layer: {MapEditor.CurrentLayer}[{(int)MapEditor.CurrentLayer}]";
            GridCheckBox.Checked = MapEditor.ShowGrid;
        }

        private void InterfaceForm_Load(object sender, EventArgs e)
        {
            PalleteComboBox.Items.Insert(0, "spritesheet-0");
            PalleteComboBox.Items.Insert(1, "spritesheet-1");
            PalleteComboBox.Items.Insert(2, "spritesheet-2");
            PalleteComboBox.Items.Insert(3, "spritesheet-3");
        }

        private void PalleteComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            App.Info($"index: {PalleteComboBox.SelectedIndex}");
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
                MapEditor.FormattedMapName = $"(Size: {(int)MapEditor.ActualMapSize} x {(int)MapEditor.ActualMapSize}) Map: {MapEditor.ActualMapName}";

                App.Info($"- Name: {newmap.MapName}");
                App.Info($"- Size: {(int)MapEditor.ActualMapSize} x {(int)MapEditor.ActualMapSize}");

                MapEditor.LoadTileSets(false);

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
                MapEditor.FormattedMapName = $"(Size : {(int)MapEditor.ActualMapSize} x {(int)MapEditor.ActualMapSize}) Map: {MapEditor.ActualMapName}";

                App.Info($"- Name: {loadmap.MapName}");
                App.Info($"- Size: {(int)MapEditor.ActualMapSize} x {(int)MapEditor.ActualMapSize}");

                MapEditor.LoadTileSets(false);

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