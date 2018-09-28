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

            AccountLoginRegisterDisplay.Visible = true;
            AccountLoginRegisterDisplay.Enabled = true;
            CurrentAcccountDisplay.Visible = false;
            CurrentAcccountDisplay.Enabled = false;
            AccountRegisterPopUp.Visible = false;
            AccountRegisterPopUp.Enabled = false;
            PopUpDisplay.Visible = false;
        }

        public void RegisterToggle()
        {
            AccountLoginRegisterDisplay.Visible = !AccountLoginRegisterDisplay.Visible;
            AccountLoginRegisterDisplay.Enabled = !AccountLoginRegisterDisplay.Enabled;
            AccountRegisterPopUp.Enabled = !AccountRegisterPopUp.Enabled;
            AccountRegisterPopUp.Visible = !AccountRegisterPopUp.Visible;
        }
    }
}
