using LoESoft.Launcher.Http;
using System;
using System.Drawing;
using System.Windows.Forms;
using static LoESoft.Launcher.Controls.AccountDisplay.Control.Register.RegisterEvent;

namespace LoESoft.Launcher.Controls.AccountDisplay.Control.Register
{
    public partial class RegisterBox : UserControl
    {
        private string Notifications;
        private event EventHandler<RegisterEvent> OnSend;

        public RegisterBox()
        {
            Notifications = null;
            OnSend += OnReceive;

            InitializeComponent();
        }

        private void OnReceive(object sender, RegisterEvent e) => Notifications += $"\t[ORDER]) {e.GetNotificationByFlag}|";

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
                OnSend(sender, new RegisterEvent(EventFlags.ACCOUNT_NAME_INVALID_LENGTH));

            if (string.IsNullOrWhiteSpace(AccountNameTextBox.Text))
                OnSend(sender, new RegisterEvent(EventFlags.ACCOUNT_NAME_NULL_OR_EMPTY));

            if (PasswordTextBox.Text.Length < 8 || ConfirmPasswordTextBox.Text.Length < 8)
                OnSend(sender, new RegisterEvent(EventFlags.ACCOUNT_PASSWORD_INVALID_LENGTH));

            if (string.IsNullOrWhiteSpace(PasswordTextBox.Text) || string.IsNullOrWhiteSpace(ConfirmPasswordTextBox.Text))
                OnSend(sender, new RegisterEvent(EventFlags.ACCOUNT_PASSWORD_NULL_OR_EMPTY));

            if (PasswordTextBox.Text != ConfirmPasswordTextBox.Text)
                OnSend(sender, new RegisterEvent(EventFlags.ACCOUNT_PASSWORD_DOESNT_MATCH));

            var parent = ((RegisterControl)Parent);
            var query = new HttpEngineQuery();
            query.AddQuery("name", AccountNameTextBox.Text);
            query.AddQuery("password", PasswordTextBox.Text);

            Enabled = false;

            GameLauncher.Info($"Is Notifications null? {Notifications == null}.");

            if (Notifications != null)
            {
                GameLauncher.Info(GetNotifications());

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
            }
            else
            {
                GameLauncher.Info("Dispatching request to the web server...");

                HttpEngine.Handle(
                    PacketID.LOGIN,
                    query,
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
                            Title = "Register Denied",
                            Content = error,
                            Alignment = ContentAlignment.MiddleCenter,
                            OnDisplay = () => parent.SetPopUpBoxVisibility(true),
                            OnClose = () => Enabled = true
                        });
                    });
            }
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
