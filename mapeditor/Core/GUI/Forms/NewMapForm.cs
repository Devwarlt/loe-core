using System;
using System.Windows.Forms;

namespace LoESoft.MapEditor.Core.GUI.Forms
{
    public partial class NewMapForm : Form
    {
        public string MapName { get; set; }
        public int MapWidth { get; set; }
        public int MapHeight { get; set; }

        public NewMapForm()
        {
            InitializeComponent();
        }

        private void Create_Click(object sender, EventArgs e)
        {
            try
            {
                var size = Sizes.SelectedText.Split('x')[0];
                var exist = Enum.IsDefined(typeof(MapSize), size);

                if (exist)
                {
                    MapName = MapFileName.Text;
                    MapWidth = int.Parse(size);
                    MapHeight = int.Parse(size);

                    DialogResult = DialogResult.OK;
                }
                else
                    DialogResult = DialogResult.Retry;
            }
            catch
            {
                MessageBox.Show("Invalid size!");

                DialogResult = DialogResult.None;
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
            => DialogResult = DialogResult.Cancel;
    }
}