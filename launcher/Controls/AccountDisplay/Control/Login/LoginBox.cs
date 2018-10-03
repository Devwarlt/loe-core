using LoESoft.Launcher.Http;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LoESoft.Launcher.Controls.AccountDisplay.Control.Login
{
    public partial class LoginBox : UserControl
    {
        public LoginBox()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            var parent = ((LoginControl)Parent);
            var query = new HttpEngineQuery();
            query.AddQuery("name", AccountNameTextBox.Text);
            query.AddQuery("password", PasswordTextBox.Text);

            Enabled = false;

            HttpEngine.Handle(
                PacketID.LOGIN, query,
                success =>
                {
                    GameLauncher.Info(success);

                    parent.UpdatePopUp(new PopUpSettings()
                    {
                        Title = "Welcome",
                        Content = success,
                        Alignment = ContentAlignment.MiddleCenter,
                        OnDisplay = () => parent.SetPopUpBoxVisibility(true),
                        OnClose = () => Enabled = true
                    });
                },
                error =>
                {
                    GameLauncher.Warn(error);

                    parent.UpdatePopUp(new PopUpSettings()
                    {
                        Title = "Login Denied",
                        Content = error,
                        Alignment = ContentAlignment.MiddleCenter,
                        OnDisplay = () => parent.SetPopUpBoxVisibility(true),
                        OnClose = () => Enabled = true
                    });
                });
        }

        private void IsKeyDown(object sender, KeyEventArgs e)
        {
            var isCaps = IsKeyLocked(Keys.CapsLock);

            CapsLockLabel.Enabled = isCaps;
            CapsLockLabel.Visible = isCaps;
        }

        private void LoginCancelButton_Click(object sender, EventArgs e)
        {
            // Clean text box cache.
            AccountNameTextBox.Text = null;
            PasswordTextBox.Text = null;

            var parent = ((LoginControl)Parent);
            parent.ToggleLoginBox();
            parent.ToggleUI();
        }
    }
}
