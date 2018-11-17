using System;
using System.Windows.Forms;

namespace LoESoft.MapEditor.Core.GUI
{
    public partial class LoadMapForm : Form
    {
        public string MapName { get; set; }
        public string MapPath { get; set; }

        private bool _folderChoosen { get; set; }

        public LoadMapForm() => InitializeComponent();

        private void BrowseFolder_Click(object sender, EventArgs e)
        {
            var browsedialog = new OpenFileDialog { Multiselect = false };

            if (browsedialog.ShowDialog() == DialogResult.OK)
            {
                MapName = browsedialog.SafeFileName.Replace(".json", string.Empty);
                MapPath = browsedialog.FileName;

                _folderChoosen = true;

                MapNameLabel.Text = $"Map Name: {MapName}";
                MapPathLabel.Text = $"Map Path: {MapPath}";
            }
            else
                _folderChoosen = false;
        }

        private void Load_Click(object sender, EventArgs e)
        {
            if (_folderChoosen)
                DialogResult = DialogResult.OK;
            else
                MessageBox.Show("You need to select folder to load map.");
        }

        private void Cancel_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
    }
}