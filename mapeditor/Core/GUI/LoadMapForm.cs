using LoESoft.MapEditor.Core.Util;
using System;
using System.IO;
using System.Windows.Forms;

namespace LoESoft.MapEditor.Core.GUI
{
    public partial class LoadMapForm : Form
    {
        private string _mapName { get; set; }
        private string _folderPath { get; set; }
        private bool _folderChoosen { get; set; }

        public LoadMapForm() => InitializeComponent();

        private void BrowseFolder_Click(object sender, EventArgs e)
        {
            var browsedialog = new OpenFileDialog { Multiselect = false };

            if (browsedialog.ShowDialog() == DialogResult.OK)
            {
                _mapName = browsedialog.SafeFileName;
                _folderPath = browsedialog.FileName;
                _folderChoosen = true;

                MapNameLabel.Text = $"Map Name: {_mapName}";
                MapPathLabel.Text = $"Map Path: {_folderPath}";
            }
            else
                _folderChoosen = false;
        }

        private void Load_Click(object sender, EventArgs e)
        {
            if (_folderChoosen)
            {
                App.Info($"Loaded map from '{_folderPath}'.");

                MapEditor.Map.Load(_mapName.Replace(".json", string.Empty), File.ReadAllText(_folderPath));

                DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("You need to select folder to load map.");
        }

        private void Cancel_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
    }
}