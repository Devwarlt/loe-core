using System;
using System.Windows.Forms;

namespace LoESoft.MapEditor.Core.GUI
{
    public partial class NewMapForm : Form
    {
        public string MapName { get; set; }
        public MapSize MapSize { get; set; }

        public NewMapForm()
        {
            InitializeComponent();
        }

        private void NewMapForm_Load(object sender, EventArgs e) => MapSize = MapSize.SIZE_128;

        private void Create_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(MapFileName.Text))
            {
                MessageBox.Show("Map name is empty!");
                return;
            }

            MapName = MapFileName.Text;

            DialogResult = DialogResult.OK;
        }

        private void Cancel_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void Size128_CheckedChanged(object sender, EventArgs e) => MapSize = MapSize.SIZE_128;

        private void Size256_CheckedChanged(object sender, EventArgs e) => MapSize = MapSize.SIZE_256;

        private void Size384_CheckedChanged(object sender, EventArgs e) => MapSize = MapSize.SIZE_384;

        private void Size512_CheckedChanged(object sender, EventArgs e) => MapSize = MapSize.SIZE_512;

        private void Size768_CheckedChanged(object sender, EventArgs e) => MapSize = MapSize.SIZE_768;

        private void Size1024_CheckedChanged(object sender, EventArgs e) => MapSize = MapSize.SIZE_1024;
    }
}