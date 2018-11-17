using LoESoft.MapEditor.Core.Layer;
using LoESoft.MapEditor.Core.Util;
using System;
using System.Windows.Forms;

namespace LoESoft.MapEditor.Core.GUI
{
    public partial class LoadMapForm : Form
    {
        public Map Map { get; set; }
        public string MapName { get; set; }

        public LoadMapForm() => InitializeComponent();

        private void Load_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(MapNameTextBox.Text))
                MessageBox.Show("Map name is empty!");
            else
            {
                var map = Utils.LoadMap(MapNameTextBox.Text);

                if (map == null)
                    MessageBox.Show($"Map '{MapNameTextBox.Text}' not found!");
                else
                {
                    App.Info($"chunk [0, 0] of layer 0: {map.Layers[0].Chunk[0, 0]}");

                    Map = map;
                    MapName = MapNameTextBox.Text;
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void Cancel_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
    }
}