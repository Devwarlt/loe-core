using System.Windows.Forms;

namespace LoESoft.Launcher.Controls.AccountDisplay
{
    public partial class Main : UserControl
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_EnabledChanged(object sender, System.EventArgs e)
        {
            if (!Enabled)
                return;

            // Hide the rest of controls.
            LoginControl.Visible = false;
            LoginControl.Enabled = false;

            RegisterControl.Visible = false;
            RegisterControl.Enabled = false;

            // Display only buttons 'LoginButton' and 'RegisterButton'.
            LoginButton.Visible = true;
            LoginButton.Enabled = true;

            RegisterButton.Visible = true;
            RegisterButton.Enabled = true;
        }

        private void LoginButton_Click(object sender, System.EventArgs e)
        {
            ToggleButtons();
            ToggleLoginControl();
        }

        private void RegisterButton_Click(object sender, System.EventArgs e)
        {
            ToggleButtons();
            ToggleRegisterControl();
        }

        public void ToggleButtons()
        {
            LoginButton.Enabled = !LoginButton.Enabled;

            RegisterButton.Enabled = !RegisterButton.Enabled;
        }

        public void ToggleLoginControl()
        {
            LoginControl.Visible = !LoginControl.Visible;
            LoginControl.Enabled = !LoginControl.Enabled;
            LoginControl.ToggleLoginBox();
        }

        public void ToggleRegisterControl()
        {
            RegisterControl.Visible = !RegisterControl.Visible;
            RegisterControl.Enabled = !RegisterControl.Enabled;
            RegisterControl.ToggleRegisterBox();
        }
    }
}
