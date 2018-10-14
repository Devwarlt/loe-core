using System.Windows.Forms;

namespace LoESoft.Launcher.Controls.AccountDisplay.Control.Updater
{
    public partial class UpdaterBox : UserControl
    {
        public UpdaterBox()
        {
            InitializeComponent();
        }

        public void SetContent(string content) => UpdateLabel.Text = content;
    }
}
