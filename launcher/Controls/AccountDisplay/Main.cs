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

            UpdaterControl.Visible = false;
            UpdaterControl.Enabled = false;

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

        public void ToggleUpdaterControl()
        {
            UpdaterControl.Visible = !UpdaterControl.Visible;
            UpdaterControl.Enabled = !UpdaterControl.Enabled;
            UpdaterControl.ToggleUpdaterBox();
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
            query.AddQuery("version", /*GameLauncher._version*/"0.1.1");

            HttpEngine.Handle(PacketID.CHECK_VERSION, query,
                success =>
                {
                    GameLauncher.Info("Start game client.");

                    // TODO: launch the game client.
                },
                error =>
                {
                    BackToMenu();

                    GameLauncher.Info(error);

                    if (error.Contains("released"))
                    {
                        UpdaterControl.GetUpdateInfo(error);
                        ToggleUpdaterControl();
                    }
                    else
                        UpdaterControl.UpdatePopUp(new PopUpSettings()
                        {
                            Title = "Update Denied",
                            Content = error,
                            Alignment = ContentAlignment.MiddleLeft,
                            OnDisplay = () => UpdaterControl.SetPopUpBoxVisibility(true),
                            OnClose = () => UpdaterControl.ToggleUI()
                        });
                });
        }
    }
}