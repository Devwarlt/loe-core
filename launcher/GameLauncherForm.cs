using LoESoft.Launcher.Controls;
using LoESoft.Launcher.Http;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LoESoft.Launcher
{
    public partial class GameLauncherForm : Form
    {
        public ExtendedButton SelectedDisplay { get; set; }

        public GameLauncherForm()
        {
            InitializeComponent();

            GameLauncher.Info("Game Launcher is loading... OK!");
        }

        public void Reload() => ChangeButtonSelected(SelectedDisplay, new EventArgs());

        private void ChangeButtonSelected(object sender, EventArgs e)
        {
            var button = (ExtendedButton)sender;

            if (button == ExitButton)
                Environment.Exit(0);

            SelectedDisplay.SetInActive();
            SelectedDisplay = button;
            SelectedDisplay.SetActive();
        }

        private void LauncherForm_FormClosed(object sender, FormClosedEventArgs e) => Account.UserAccount.SaveAccount();

        public void UpdatePopUp(PopUpSettings settings, bool enabled = true)
        {
            PopUpBox.Settings = settings;
            PopUpBox.LoadSettings();
            PopUpBox.SetSubmit(enabled);
        }

        private void LauncherForm_Load(object sender, EventArgs e)
        {
            LauncherVersionLabel.Text = GameLauncherParameters.LAUNCHER_VERSION;
            SelectedDisplay = HomeButton;

            if (string.IsNullOrWhiteSpace(Settings.LauncherSettings.AutoLogin))
                if (!Convert.ToBoolean(Settings.LauncherSettings.AutoLogin))
                {
                    AccountButton.Enabled = true;
                    OptionsButton.Enabled = true;
                    ExitButton.Enabled = true;
                    return;
                }

            AccountButton.Enabled = false;
            OptionsButton.Enabled = false;
            ExitButton.Enabled = false;

            PopUpBox.Visible = false;

            if (!string.IsNullOrWhiteSpace(Account.UserAccount.LoginToken))
            {
                var query = new HttpEngineQuery();
                query.AddQuery("token", Account.UserAccount.LoginToken);

                HttpEngine.Handle(
                    PacketID.LOGIN_TOKEN,
                    query,
                    success => UpdatePopUp(new PopUpSettings()
                    {
                        Title = "Welcome",
                        Content = "You have successfully logged in, enjoy the game!",
                        Alignment = ContentAlignment.MiddleCenter,
                        OnDisplay = () => PopUpBox.Visible = true,
                        OnClose = () =>
                        {
                            AccountButton.Enabled = true;
                            OptionsButton.Enabled = true;
                            ExitButton.Enabled = true;
                        }
                    }),
                    error => UpdatePopUp(new PopUpSettings()
                    {
                        Title = "Login Denied",
                        Content = error,
                        Alignment = ContentAlignment.MiddleCenter,
                        OnDisplay = () =>
                        {
                            Account.UserAccount.Invalidate();

                            PopUpBox.Visible = true;
                        },
                        OnClose = () =>
                        {
                            AccountButton.Enabled = true;
                            OptionsButton.Enabled = true;
                            ExitButton.Enabled = true;
                        }
                    }));
            }
            else
                UpdatePopUp(new PopUpSettings()
                {
                    Title = "Invalid Token",
                    Content = "Account token not found, make sure to login next time to avoid this message.",
                    Alignment = ContentAlignment.MiddleCenter,
                    OnDisplay = () => PopUpBox.Visible = true,
                    OnClose = () =>
                    {
                        AccountButton.Enabled = true;
                        OptionsButton.Enabled = true;
                        ExitButton.Enabled = true;
                    }
                });
        }
    }
}