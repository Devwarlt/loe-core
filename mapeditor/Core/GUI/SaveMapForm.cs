using System;
using System.IO;
using System.Windows.Forms;

namespace LoESoft.MapEditor.Core.GUI
{
    public partial class SaveMapForm : Form
    {
        private string _mapName { get; set; }
        private string _mapContent { get; set; }
        private string _folderPath { get; set; }
        private bool _folderChoosen { get; set; }

        public SaveMapForm(string mapName, string mapContent)
        {
            _mapName = mapName;
            _mapContent = mapContent;

            InitializeComponent();
        }

        private void SaveMapForm_Load(object sender, EventArgs e)
        {
            MapNameTextBox.Text = _mapName;
            MapPathLabel.Text = $"Map Path: empty";
        }

        private void BrowseFolder_Click(object sender, EventArgs e)
        {
            var browsedialog = new FolderBrowserDialog();

            if (browsedialog.ShowDialog() == DialogResult.OK)
            {
                _folderPath = Path.Combine(browsedialog.SelectedPath, $"{_mapName}.json");
                _folderChoosen = true;

                MapPathLabel.Text = $"Map Path: {browsedialog.SelectedPath}";
            }
            else
                _folderChoosen = false;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (_folderChoosen)
            {
                App.Info($"Saved map to '{_folderPath}'.");

                File.WriteAllText(_folderPath, _mapContent);

                DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("You need to select folder to save map.");
        }

        private void Cancel_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void MapNameTextBox_TextChanged(object sender, EventArgs e)
        {
            _mapName = string.IsNullOrEmpty(MapNameTextBox.Text) ? "new_map" : MapNameTextBox.Text;

            MapNameLabel.Text = $"Map Name: {_mapName}.json";
        }
    }
}