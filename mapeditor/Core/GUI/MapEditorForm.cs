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
    }
}