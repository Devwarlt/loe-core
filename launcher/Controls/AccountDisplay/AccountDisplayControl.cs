using System.Windows.Forms;

namespace LoESoft.Launcher.Controls.AccountDisplay
{
    public partial class AccountDisplayControl : UserControl
    {
        public AccountDisplayControl()
        {
            InitializeComponent();
        }

        private void AccountDisplayControl_EnabledChanged(object sender, System.EventArgs e)
        {
            if (!Enabled)
                return;

            var account = Account.UserAccount;
            if (!string.IsNullOrWhiteSpace(account.LoginToken))
            {
                AccountLoginDisplay.Enabled = false;
                AccountLoginDisplay.Visible = false;
                return;
            }
            AccountLoginDisplay.Enabled = true;
            AccountLoginDisplay.Visible = true;
        }
    }
}
