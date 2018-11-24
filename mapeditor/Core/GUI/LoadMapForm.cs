using LoESoft.MapEditor.Core.GUI.HUD;
using LoESoft.MapEditor.Core.Layer;
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
                var map = MEGameControl.Mapper.LoadMap(MapNameTextBox.Text);

                if (map == default(Map))
                    MessageBox.Show($"Map '{MapNameTextBox.Text}' not found!");
                else
                {
                    Map = map;
                    MapName = MapNameTextBox.Text;
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void Cancel_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
    }
}