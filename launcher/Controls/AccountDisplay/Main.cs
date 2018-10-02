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

            // Display only buttons 'LoginButton' and 'RegisterButton'.
            LoginButton.Visible = true;
            LoginButton.Enabled = true;

            RegisterButton.Visible = true;
            RegisterButton.Enabled = true;

            // Hide the rest of boxes.
            LoginBox.Visible = false;
            LoginBox.Enabled = false;

            RegisterBox.Visible = false;
            RegisterBox.Enabled = false;

            SetPopUpBoxVisibility(false);
        }

        private void LoginButton_Click(object sender, System.EventArgs e)
        {
            ToggleButtons();
            ToggleLoginBox();
        }

        private void RegisterButton_Click(object sender, System.EventArgs e)
        {
            ToggleButtons();
            ToggleRegisterBox();
        }

        public void ToggleButtons()
        {
            LoginButton.Enabled = !LoginButton.Enabled;

            RegisterButton.Enabled = !RegisterButton.Enabled;
        }

        public void ToggleLoginBox()
        {
            LoginBox.Visible = !LoginBox.Visible;
            LoginBox.Enabled = !LoginBox.Enabled;
        }

        public void ToggleRegisterBox()
        {
            RegisterBox.Visible = !RegisterBox.Visible;
            RegisterBox.Enabled = !RegisterBox.Enabled;
        }

        public void SetPopUpBoxVisibility(bool visible) => PopUpBox.Visible = visible;

        public void UpdatePopUp(PopUpSettings settings)
        {
            PopUpBox.Settings = settings;
            PopUpBox.LoadSettings();
        }
    }
}
