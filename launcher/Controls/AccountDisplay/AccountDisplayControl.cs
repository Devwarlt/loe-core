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

            var isLoggedIn = !string.IsNullOrWhiteSpace(account.LoginToken);

            CurrentAccountDisplay.Enabled = isLoggedIn;
            CurrentAccountDisplay.Visible = isLoggedIn;
            AccountLoginDisplay.Enabled = !isLoggedIn;
            AccountLoginDisplay.Visible = !isLoggedIn;

            LoginRegisterDisplay.Enabled = false;
            LoginRegisterDisplay.Visible = false;
            PopUpDisplay.Visible = false;
        }

        public void RegisterToggle()
        {
            LoginRegisterDisplay.Visible = !LoginRegisterDisplay.Visible;
            LoginRegisterDisplay.Enabled = !LoginRegisterDisplay.Enabled;
            AccountLoginDisplay.Visible = !AccountLoginDisplay.Visible;
            AccountLoginDisplay.Enabled = !AccountLoginDisplay.Enabled;
        }

        public void ClickToggle()
        {
            LoginRegisterDisplay.Enabled = !LoginRegisterDisplay.Enabled;
            AccountLoginDisplay.Enabled = !AccountLoginDisplay.Enabled;
        }

        public void PopUpToggle() => PopUpDisplay.Visible = !PopUpDisplay.Visible;

        public void PopUpUpdate(string title, string text)
        {
            PopUpDisplay.SetTitle(title);
            PopUpDisplay.SetText(text);
        }
    }
}
