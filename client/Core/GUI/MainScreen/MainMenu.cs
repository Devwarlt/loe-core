using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.GUI.GameDialog;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LoESoft.Client.Core.GUI.MainScreen
{
    public partial class MainMenu : UserControl
    {
        public bool LoggedIn { get; set; }
        public GameUser GameUser { get; set; }

        public Queue<Action> ToggleActions;
        public InternalClock Clock { get; set; }

        public delegate void ToggleDelegate(string type);

        public ToggleDelegate Toggle { get; set; }

        public MainMenu()
        {
            InitializeComponent();

            ToggleActions = new Queue<Action>();
            Toggle = (text) => ToggleBox(text);
            Clock = new InternalClock(500, delegate
            {
                if (ToggleActions.Count > 0)
                    ToggleActions.Dequeue()?.Invoke();
            });
            Clock.Start();
        }

        public void SetGameDialog(bool visible)
        {
            GameDialog.Visible = visible;
            GameDialog.Enabled = visible;
        }

        public void UpdateGameDialog(GameDialogSettings settings)
        {
            GameDialog.Settings = settings;
            GameDialog.LoadSettings();
        }

        public void QueueAction(Action action) => ToggleActions.Enqueue(action);

        public void ToggleBox(string type)
        {
            if (LoginBox.InvokeRequired || RegisterBox.InvokeRequired || PlayButton.InvokeRequired || LoginBox.InvokeRequired)
                Invoke(Toggle, new object[] { type });
            else
            {
                switch (type)
                {
                    case "Login":
                        LoggedIn = true;
                        LoginBox.Toggle();
                        LoginButton.Enabled = LoggedIn;
                        LoginButton.Text = "Logout";

                        PlayButton.Enabled = true;
                        ExitButton.Enabled = true;
                        break;

                    case "Register":
                        LoginButton.Enabled = true;
                        ExitButton.Enabled = true;
                        break;
                }
            }
        }

        public void OnBoxClose()
        {
            LoginButton.Enabled = true;
            RegisterButton.Enabled = true;
            ExitButton.Enabled = true;
            PlayButton.Enabled = false;
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            LoggedIn = false;
            PlayButton.Enabled = LoggedIn;

            BRMEVersion.Text = $"Version: {App.Version}";
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