using LoESoft.MapEditor.Core.GUI.HUD;
using System.Windows.Forms;

namespace LoESoft.MapEditor.Core.GUI
{
    public partial class MapEditorForm : Form
    {
        public MapEditorForm()
        {
            InitializeComponent();

            App.MapControl = monoGameWindow1;
            MEGameControl.HUD = hud1;
        }

        private void MapEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var box = MessageBox.Show("Do you want to exit?", "Exit", MessageBoxButtons.YesNo);

            if (box == DialogResult.Yes)
                Application.ExitThread();

            e.Cancel = true;
        }
    }
}