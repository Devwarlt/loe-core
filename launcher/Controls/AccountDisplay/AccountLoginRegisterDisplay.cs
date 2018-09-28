using System.Windows.Forms;

namespace LoESoft.Launcher.Controls.AccountDisplay
{
    public partial class AccountLoginRegisterDisplay : UserControl
    {
        public AccountLoginRegisterDisplay()
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
