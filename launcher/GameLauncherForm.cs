using LoESoft.Launcher.Controls;
using LoESoft.Launcher.Http;
using System;
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

        private void LauncherForm_Load(object sender, EventArgs e)
        {
            LauncherVersionLabel.Text = GameLauncherParameters.LAUNCHER_VERSION;
            SelectedDisplay = HomeButton;

            var account = Account.LoadAccount();

            if (!string.IsNullOrWhiteSpace(account.LoginToken)) // if already logged in
            {
                var httpEngine = HttpEngine.CreateRequest(PacketID.LOGIN_TOKEN);
                var query = new HttpEngineQuery();
                query.AddQuery("token", account.LoginToken);

                httpEngine.SendRequest(null, error =>
                {
                    account.Invalidate();
                    GameLauncher.Info("Unable to relogin");
                }, query);
            }
        }
    }
}
