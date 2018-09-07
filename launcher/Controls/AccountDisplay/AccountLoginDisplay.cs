using System.Windows.Forms;

namespace LoESoft.Launcher.Controls.AccountDisplay
{
    public partial class AccountLoginDisplay : UserControl
    {
        public AccountLoginDisplay()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, System.EventArgs e) { }

        private void RegisterButton_Click(object sender, System.EventArgs e)
        {
            ((AccountDisplayControl)Parent).RegisterToggle();
        }
    }
}
