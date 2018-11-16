using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.GUI.GameDialog;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LoESoft.Client.Core.GUI.MainScreen
{
    public partial class MainMenu : UserControl
    {
        public Queue<Action> ToggleActions;

        public bool LoggedIn { get; set; }
        public GameUser GameUser { get; set; }
        public InternalClock Clock { get; set; }

        private SetGameDialogDelegate SetDialog { get; set; }
        private UpdateGameDialogDelegate UpdateDialog { get; set; }
        private ToggleBoxDelegate OnEnableBox { get; set; }
        private EnableButtonDelegate EnableButton { get; set; }
        private RenameLoginButtonDelegate OnRenameButton { get; set; }

        private delegate void SetGameDialogDelegate(bool visible);

        private delegate void UpdateGameDialogDelegate(GameDialogSettings settings);

        private delegate void ToggleBoxDelegate(string box);

        private delegate void EnableButtonDelegate(string button, bool enable);

        private delegate void RenameLoginButtonDelegate(bool logged);

        public MainMenu()
        {
            InitializeComponent();

            ToggleActions = new Queue<Action>();
            SetDialog = (visible) => SetGameDialog(visible);
            UpdateDialog = (settings) => UpdateGameDialog(settings);
            OnEnableBox = (box) => EnableBox(box);
            EnableButton = (button, enable) => OnEnableButton(button, enable);
            OnRenameButton = (logged) => OnRenameLoginButton(logged);
            Clock = new InternalClock(100, delegate
            {
                if (ToggleActions.Count > 0)
                    ToggleActions.Dequeue()?.Invoke();
            });
            Clock.Start();

            SetGameDialog(false);
        }

        public void SetGameDialog(bool visible)
        {
            if (GameDialog.InvokeRequired)
                Invoke(SetDialog, new object[] { visible });
            else
                GameDialog.Visible = visible;
        }

        public void UpdateGameDialog(string titleSuccess, string titleError, string content, Action success, Action error, bool result, ContentAlignment alignment = ContentAlignment.MiddleCenter)
        {
            var settings = new GameDialogSettings()
            {
                Title = result ? titleSuccess : titleError,
                Content = content,
                Alignment = alignment,
                OnDisplay = () => QueueAction(success),
                OnClose = () => QueueAction(error)
            };

            UpdateGameDialog(settings);
        }

        public void UpdateGameDialog(GameDialogSettings settings)
        {
            if (InvokeRequired)
                Invoke(UpdateDialog, new object[] { settings });
            else
            {
                GameDialog.Settings = settings;
                GameDialog.LoadSettings();
            }
        }

        public void EnableBox(string box)
        {
            if (LoginBox.InvokeRequired || RegisterBox.InvokeRequired)
                Invoke(OnEnableBox, new object[] { box });
            else
            {
                switch (box)
                {
                    case "login": LoginBox.Enabled = !LoginBox.Enabled; break;
                    case "register": RegisterBox.Enabled = !RegisterBox.Enabled; break;
                }
            }
        }

        public void OnBoxClose(string box, bool success)
        {
            switch (box)
            {
                case "login":
                    {
                        if (success)
                        {
                            LoggedIn = success;

                            OnRenameLoginButton(LoggedIn);

                            LoginBox.Toggle();

                            OnEnableButton("launch", LoggedIn);
                            OnEnableButton("login", true);
                            OnEnableButton("register", !LoggedIn);
                            OnEnableButton("exit", true);
                        }
                        else
                            EnableBox("login");
                    }
                    break;

                case "register":
                    {
                        if (success)
                        {
                            RegisterBox.Toggle();

                            OnEnableButton("launch", false);
                            OnEnableButton("login", true);
                            OnEnableButton("register", true);
                            OnEnableButton("exit", true);
                        }
                        else
                            EnableBox("register");
                    }
                    break;
            }
        }

        private void OnEnableButton(string button, bool enable)
        {
            if (LaunchButton.InvokeRequired || LoginButton.InvokeRequired || RegisterButton.InvokeRequired || ExitButton.InvokeRequired)
                Invoke(EnableButton, new object[] { button, enable });
            else
            {
                switch (button)
                {
                    case "launch": LaunchButton.Enabled = enable; break;
                    case "login": LoginButton.Enabled = enable; break;
                    case "register": RegisterButton.Enabled = enable; break;
                    case "exit": ExitButton.Enabled = enable; break;
                }
            }
        }

        private void OnRenameLoginButton(bool logged)
        {
            if (LoginButton.InvokeRequired)
                Invoke(OnRenameButton, new object[] { logged });
            else
                LoginButton.Text = logged ? "Logout" : "Login";
        }

        public void QueueAction(Action action) => ToggleActions.Enqueue(action);

        public void OnBoxClose()
        {
            LoginButton.Enabled = true;
            RegisterButton.Enabled = true;
            ExitButton.Enabled = true;
            LaunchButton.Enabled = false;
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            LoggedIn = false;
            LaunchButton.Enabled = LoggedIn;

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
                LoginBox.Enabled = true;
                LoginBox.Visible = true;

                LoginButton.Enabled = false;
                RegisterButton.Enabled = false;
                ExitButton.Enabled = false;
            }
            else
            {
                LoginButton.Text = "Login";

                LaunchButton.Enabled = false;
                RegisterButton.Enabled = true;

                LoggedIn = false;
            }
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (!LoggedIn)
            {
                RegisterBox.Enabled = true;
                RegisterBox.Visible = true;

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