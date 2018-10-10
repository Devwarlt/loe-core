using System;
using System.Windows.Forms;

namespace LoESoft.Launcher.Controls.AccountDisplay
{
    public partial class Main : UserControl
    {
        public bool IsLoggedIn;
        public EventHandler<bool> DispatchLogin;

        public Main()
        {
            DispatchLogin += LoginHandler;

            InitializeComponent();
        }

        private void LoginHandler(object sender, bool isLoggedIn)
        {
            if (sender == null)
                return;

            IsLoggedIn = isLoggedIn; // Update only.

            if (isLoggedIn)
            {
                PlayButton.Enabled = true;

                LoginLogoutButton.Text = "Logout";
                LoginLogoutButton.Click -= LoginButton_Click;
                LoginLogoutButton.Click += LogoutButton_Click;

                RegisterButton.Enabled = false;
            }
            else
            {
                PlayButton.Enabled = false;

                LoginLogoutButton.Text = "Login";
                LoginLogoutButton.Click += LoginButton_Click;
                LoginLogoutButton.Click -= LogoutButton_Click;

                RegisterButton.Enabled = true;
            }
        }

        private void Main_EnabledChanged(object sender, EventArgs e)
        {
            if (!Enabled)
                return;

            IsLoggedIn = !string.IsNullOrWhiteSpace(Account.UserAccount.LoginToken);

            DispatchLogin(this, IsLoggedIn);

            // Hide the rest of controls.
            LoginControl.Visible = false;
            LoginControl.Enabled = false;

            LogoutControl.Visible = false;
            LogoutControl.Enabled = false;

            RegisterControl.Visible = false;
            RegisterControl.Enabled = false;

            // Trigger only few buttons.
            PlayButton.Visible = true;

            LoginLogoutButton.Visible = true;
            LoginLogoutButton.Enabled = true;

            RegisterButton.Visible = true;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            ToggleButtons();
            ToggleLoginControl();
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            ToggleButtons();
            ToggleLogoutControl();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            ToggleButtons();
            ToggleRegisterControl();
        }

        public void ToggleButtons()
        {
            if (IsLoggedIn)
                PlayButton.Enabled = !PlayButton.Enabled;
            else
                RegisterButton.Enabled = !RegisterButton.Enabled;

            LoginLogoutButton.Enabled = !LoginLogoutButton.Enabled;
        }

        public void ToggleLoginControl()
        {
            LoginControl.Visible = !LoginControl.Visible;
            LoginControl.Enabled = !LoginControl.Enabled;
            LoginControl.ToggleLoginBox();
        }

        public void ToggleLogoutControl()
        {
            LogoutControl.Visible = !LogoutControl.Visible;
            LogoutControl.Enabled = !LogoutControl.Enabled;
            LogoutControl.ToggleLogoutBox();
        }

        public void ToggleRegisterControl()
        {
            RegisterControl.Visible = !RegisterControl.Visible;
            RegisterControl.Enabled = !RegisterControl.Enabled;
            RegisterControl.ToggleRegisterBox();
        }
    }
}
