using LoESoft.Launcher.Http;
using LoESoft.Launcher.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;
using static LoESoft.Launcher.Controls.AccountDisplay.ControlEvent;

namespace LoESoft.Launcher.Controls.AccountDisplay.Control.Register
{
    public partial class RegisterBox : UserControl
    {
        private string Notifications;
        private event EventHandler<ControlEvent> OnSend;

        public RegisterBox()
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

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (AccountNameTextBox.Text.Length < 6)
                OnSend(sender, new ControlEvent(EventFlags.ACCOUNT_NAME_INVALID_LENGTH));

            if (string.IsNullOrWhiteSpace(AccountNameTextBox.Text))
                OnSend(sender, new ControlEvent(EventFlags.ACCOUNT_NAME_NULL_OR_EMPTY));

            if (PasswordTextBox.Text.Length < 8)
                OnSend(sender, new ControlEvent(EventFlags.ACCOUNT_PASSWORD_INVALID_LENGTH));

            if (string.IsNullOrWhiteSpace(PasswordTextBox.Text) || string.IsNullOrWhiteSpace(ConfirmPasswordTextBox.Text))
                OnSend(sender, new ControlEvent(EventFlags.ACCOUNT_PASSWORD_NULL_OR_EMPTY));

            if (PasswordTextBox.Text != ConfirmPasswordTextBox.Text)
                OnSend(sender, new ControlEvent(EventFlags.ACCOUNT_PASSWORD_DOESNT_MATCH));

            var name = Cipher.Encrypt(AccountNameTextBox.Text);
            var pass = Cipher.Encrypt(PasswordTextBox.Text);
            var parent = ((RegisterControl)Parent);
            var query = new HttpEngineQuery();
            query.AddQuery("name", name);
            query.AddQuery("password", pass);

            Enabled = false;

            if (Notifications != null)
                parent.UpdatePopUp(new PopUpSettings()
                {
                    Title = "Register Denied",
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
                    PacketID.REGISTER,
                    query,
                    success => parent.UpdatePopUp(new PopUpSettings()
                    {
                        Title = "Welcome",
                        Content = "You have successfully registered a brand-new account, enjoy the game!",
                        Alignment = ContentAlignment.MiddleCenter,
                        OnDisplay = () =>
                        {
                            // Store login token.
                            Account.UserAccount.LoginToken = success;
                            Account.UserAccount.SaveAccount();

                            parent.SetPopUpBoxVisibility(true);

                            RegisterCancelButton_Click(null, null); // remove UI when success
                        },
                        OnClose = () => Enabled = true
                    }),
                    error =>
                    parent.UpdatePopUp(new PopUpSettings()
                    {
                        Title = "Register Denied",
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

        private void RegisterCancelButton_Click(object sender, EventArgs e)
        {
            // Clean text box cache.
            AccountNameTextBox.Text = null;
            PasswordTextBox.Text = null;
            ConfirmPasswordTextBox.Text = null;

            var parent = ((RegisterControl)Parent);
            parent.ToggleRegisterBox();
            parent.ToggleUI();
        }
    }
}
