using LoESoft.Client.Core.Client;
using System;
using System.Windows.Forms;

namespace LoESoft.Client.Core.GUI.MainScreen
{
    public partial class MainMenu : UserControl
    {
        public bool LoggedIn { get; set; }
        public GameUser GameUser { get; set; }

        public MainMenu() => InitializeComponent();

        private void MainScreen_Load(object sender, EventArgs e)
        {
            LoggedIn = false;
            PlayButton.Enabled = LoggedIn;

            BRMEVersion.Text = $"Version: {App.Version}";
        }

        public void ToggleLoginBox() => LoginBox.Enabled = !LoginBox.Enabled;

        public void OnLoginBoxClose(bool success = false)
        {
            if (!success)
                LoginBox.Toggle();

            if (LoggedIn)
                LoginButton.Text = "Logout";
            
            LoginButton.Enabled = true;
            RegisterButton.Enabled = !LoggedIn;
            ExitButton.Enabled = true;
            
            PlayButton.Enabled = !PlayButton.Enabled;

            App.Warn($"{LoggedIn}");
        }

        public void ToggleRegisterBox() => RegisterBox.Enabled = !RegisterBox.Enabled;

        public void OnRegisterBoxClose(bool success = false)
        {
            if (!success)
                RegisterBox.Toggle();

            LoginButton.Enabled = true;
            RegisterButton.Enabled = true;
            ExitButton.Enabled = true;
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            ((Launcher)Parent).Display(null, false); // hide launcher

            try
            {
                using (var game = new GameApplication(GameUser))
                    game.Run();
            }
            catch (Exception ex) { App.Error(ex); }

            ((Launcher)Parent).Display(null, true); // display launcher
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (!LoggedIn)
            {
                LoginBox.Toggle();

                LoginButton.Enabled = false;
                RegisterButton.Enabled = false;
                ExitButton.Enabled = false;
            }
            else
            {
                App.Info("You have been logged out!");

                LoginButton.Text = "Login";

                PlayButton.Enabled = false;
                RegisterButton.Enabled = true;

                LoggedIn = false;
            }
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (!LoggedIn)
            {
                RegisterBox.Toggle();

                LoginButton.Enabled = false;
                RegisterButton.Enabled = false;
                ExitButton.Enabled = false;
            }
            else
                App.Info("You cannot register when already logged in!");
        }

        private void ExitButton_Click(object sender, EventArgs e) => Environment.Exit(0);
    }
}