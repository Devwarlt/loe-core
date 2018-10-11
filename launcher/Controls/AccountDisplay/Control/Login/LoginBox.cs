using LoESoft.Launcher.Http;
using LoESoft.Launcher.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;
using static LoESoft.Launcher.Controls.AccountDisplay.ControlEvent;

namespace LoESoft.Launcher.Controls.AccountDisplay.Control.Login
{
    public partial class LoginBox : UserControl
    {
        private string Notifications;
        private event EventHandler<ControlEvent> OnSend;

        public LoginBox()
        {
            Notifications = null;
            OnSend += OnReceive;

            InitializeComponent();
        }

        private void OnReceive(object sender, ControlEvent e) => Notifications += $"[ORDER]) {e.GetNotificationByFlag}|";

        private string GetNotifications()
        {
            string[] notifications = Notifications.Split('|');
            string data = "An error occurred, check below:\r\n\r\n";

            if (notifications.Length > 1)
                for (int i = 0; i < notifications.Length - 1; i++)
                    data += $"{notifications[i].Replace("[ORDER]", $"{i + 1}").Replace("|", string.Empty)}{(i + 1 == notifications.Length - 1 ? "." : ";\r\n")}";
            else
                data = $"{notifications[0].Replace("[ORDER]", "1").Replace("|", string.Empty)}.";

            return data;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AccountNameTextBox.Text))
                OnSend(sender, new ControlEvent(EventFlags.ACCOUNT_NAME_NULL_OR_EMPTY));

            if (string.IsNullOrWhiteSpace(PasswordTextBox.Text))
                OnSend(sender, new ControlEvent(EventFlags.ACCOUNT_PASSWORD_NULL_OR_EMPTY));

            var name = Cipher.Encrypt(AccountNameTextBox.Text);
            var pass = Cipher.Encrypt(PasswordTextBox.Text);
            var parent = ((LoginControl)Parent);
            var query = new HttpEngineQuery();
            query.AddQuery("name", name);
            query.AddQuery("password", pass);

            Enabled = false;

            if (Notifications != null)
                parent.UpdatePopUp(new PopUpSettings()
                {
                    Title = "Login Denied",
                    Content = GetNotifications(),
                    Alignment = ContentAlignment.MiddleLeft,
                    OnDisplay = () => parent.SetPopUpBoxVisibility(true),
                    OnClose = () =>
                    {
                        Enabled = true;
                        Notifications = null;
                    }
                });
            else
                HttpEngine.Handle(
                    PacketID.LOGIN, query,
                    success => parent.UpdatePopUp(new PopUpSettings()
                    {
                        Title = "Welcome",
                        Content = "You have successfully logged in, enjoy the game!",
                        Alignment = ContentAlignment.MiddleCenter,
                        OnDisplay = () =>
                        {
                            // Store login token.
                            Account.UserAccount.LoginToken = success;
                            Account.UserAccount.SaveAccount();

                            parent.SetPopUpBoxVisibility(true);
                        },
                        OnClose = () =>
                        {
                            Enabled = true;
                            LoginCancelButton_Click(null, null); // remove UI when sucess
                        }
                    }),
                    error => parent.UpdatePopUp(new PopUpSettings()
                    {
                        Title = "Login Denied",
                        Content = error,
                        Alignment = ContentAlignment.MiddleCenter,
                        OnDisplay = () => parent.SetPopUpBoxVisibility(true),
                        OnClose = () => Enabled = true
                    }));
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

            if (sender == null && e == null)
                parent.UpdateLabels();
        }
    }
}
