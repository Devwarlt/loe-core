using LoESoft.Launcher.Http;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LoESoft.Launcher.Controls.AccountDisplay
{
    public partial class Main : UserControl
    {
        public bool IsLoggedIn;
        public EventHandler<Tuple<bool, bool>> DispatchLogin;

        public Main()
        {
            DispatchLogin += LoginHandler;

            InitializeComponent();
        }

        private void LoginHandler(object sender, Tuple<bool, bool> isLoggedIn)
        {
            if (sender == null)
                return;

            IsLoggedIn = isLoggedIn.Item1; // Update only.

            if (IsLoggedIn)
            {
                PlayButton.Enabled = true;

                LoginLogoutButton.Text = "Logout";
                if (!isLoggedIn.Item2) LoginLogoutButton.Click -= LoginButton_Click;
                LoginLogoutButton.Click += LogoutButton_Click;

                RegisterButton.Enabled = false;
            }
            else
            {
                PlayButton.Enabled = false;

                LoginLogoutButton.Text = "Login";
                LoginLogoutButton.Click += LoginButton_Click;
                if (!isLoggedIn.Item2) LoginLogoutButton.Click -= LogoutButton_Click;

                RegisterButton.Enabled = true;
            }
        }

        private void Main_EnabledChanged(object sender, EventArgs e)
        {
            if (!Enabled)
                return;

            IsLoggedIn = !string.IsNullOrWhiteSpace(Account.UserAccount.LoginToken);

            DispatchLogin(this, new Tuple<bool, bool>(IsLoggedIn, true));

            // Hide the rest of controls.
            LoginControl.Visible = false;
            LoginControl.Enabled = false;

            LogoutControl.Visible = false;
            LogoutControl.Enabled = false;

            RegisterControl.Visible = false;
            RegisterControl.Enabled = false;

            UpdateControl.Visible = false;
            UpdateControl.Enabled = false;

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

        public void BackToMenu(bool onCancel = false)
        {
            RegisterButton.Enabled = false;

            if (onCancel)
            {
                PlayButton.Enabled = true;

                LoginLogoutButton.Enabled = true;
            }
            else
            {
                PlayButton.Enabled = false;

                LoginLogoutButton.Enabled = false;
            }
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (!IsLoggedIn)
            {
                DispatchLogin(this, new Tuple<bool, bool>(false, false)); // prevent possible invalid play
                return;
            }

            var query = new HttpEngineQuery();
            query.AddQuery("version", GameLauncher._version);

            HttpEngine.Handle(PacketID.CHECK_VERSION, query,
                success =>
                {
                    // TODO: launch the game client.
                },
                error =>
                {
                    BackToMenu();

                    if (error.Contains("released"))
                        UpdateControl.ToggleUpdateBox();
                    else
                    {
                        UpdateControl.UpdatePopUp(new PopUpSettings()
                        {
                            Title = "Update Denied",
                            Content = error,
                            Alignment = ContentAlignment.MiddleLeft,
                            OnDisplay = () => UpdateControl.SetPopUpBoxVisibility(true),
                            OnClose = () => UpdateControl.ToggleUI()
                        });
                    }
                });

            // TODO: implement UpdateBox and UpdateControl, with following features below:
            // Update running App:
            // https://visualstudiomagazine.com/articles/2017/12/15/replace-running-app.aspx
            // ZIP:
            // https://stackoverflow.com/questions/16052877/how-to-unzip-all-zip-file-from-folder-using-c-sharp-4-0-and-without-using-any-o
            // https://stackoverflow.com/questions/22133053/how-to-extract-just-the-specific-directory-from-a-zip-archive-in-c-sharp-net-4
            // https://www.youtube.com/watch?v=BH9-H-b41Ys
            // https://www.youtube.com/watch?v=aE_Wl4Pouso
            // https://www.youtube.com/watch?v=NGNQOWjkI_Y
            // https://www.youtube.com/watch?v=KZr3KI2BbyE
        }
    }
}
