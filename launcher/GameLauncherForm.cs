using LoESoft.Launcher.Controls;
using LoESoft.Launcher.Controls.AccountDisplay;
using LoESoft.Launcher.Http;
using LoESoft.Launcher.Utils;
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

            LauncherForm_SizeChanged(button, e);

            SelectedDisplay.SetInActive();
            SelectedDisplay = button;
            SelectedDisplay.SetActive();
        }

        private void LauncherForm_SizeChanged(object sender, EventArgs e)
        {
            var button = sender is ExtendedButton ? (ExtendedButton)sender : SelectedDisplay;

            ButtonSelectedDisplay.Height = button.Height;
            ButtonSelectedDisplay.Top = button.Top;
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
            //Cipher.GenerateNewRSAKeys(Cipher.KeySize.KEY_512);
            LauncherVersionLabel.Text = GameLauncherParameters.LAUNCHER_VERSION;
            SelectedDisplay = HomeButton;

            AccountButton.Enabled = false;
            OptionsButton.Enabled = false;
            ExitButton.Enabled = false;

            PopUpBox.Visible = false;

            var account = Account.LoadAccount();

            if (!string.IsNullOrWhiteSpace(account.LoginToken))
            {
                var token = Cipher.Encrypt(account.LoginToken);
                var query = new HttpEngineQuery();
                query.AddQuery("token", token);

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
                        OnDisplay = () => PopUpBox.Visible = true,
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
