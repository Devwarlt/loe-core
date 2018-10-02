using LoESoft.Launcher.Http;
using System;
using System.Windows.Forms;

namespace LoESoft.Launcher.Controls.AccountDisplay
{
    public partial class LoginBox : UserControl
    {
        public LoginBox()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            var parent = ((Main)Parent);
            var query = new HttpEngineQuery();
            query.AddQuery("name", AccountNameTextBox.Text);
            query.AddQuery("password", PasswordTextBox.Text);

            // TODO.
            /*HttpEngine.Handle(
                PacketID.LOGIN,
                query,
                success =>
                {
                    parent.PopUpDisplay.Settings = new PopUpSettings()
                    {
                        Title = "Welcome",
                        Content = success,
                        WhenDisplay = () => Visible = false,
                        WhenClose = () => parent.PopUpDisplay.Visible = !parent.PopUpDisplay.Visible
                    };
                    parent.PopUpDisplay.LoadSettings();

                    GameLauncher.Info(success);
                },
                error =>
                {
                    parent.PopUpDisplay.Settings = new PopUpSettings()
                    {
                        Title = "Login Denied",
                        Content = error,
                        WhenDisplay = () => Visible = false,
                        WhenClose = () => parent.PopUpDisplay.Visible = !parent.PopUpDisplay.Visible
                    };
                    parent.PopUpDisplay.LoadSettings();

                    GameLauncher.Warn(error);
                });*/
        }

        private void IsKeyDown(object sender, KeyEventArgs e)
        {
            var isCaps = IsKeyLocked(Keys.CapsLock);

            CapsLockLabel.Enabled = isCaps;
            CapsLockLabel.Visible = isCaps;
        }

        // TODO.
        private void LoginCancelButton_Click(object sender, EventArgs e) { }
    }
}
