using LoESoft.Client.Core.Networking;
using LoESoft.Client.Core.Networking.Packets.Outgoing;
using System;
using System.Windows.Forms;

namespace LoESoft.Client.Core.GUI.MainScreen
{
    public partial class RegisterBox : UserControl
    {
        private ToggleDelegate OnToggle { get; set; }

        private delegate void ToggleDelegate();

        public RegisterBox()
        {
            InitializeComponent();

            OnToggle = () => Toggle();

            Enabled = false;
            Visible = false;
        }

        public void Toggle()
        {
            if (InvokeRequired)
                Invoke(OnToggle);
            else
            {
                EmailBox.Text = string.Empty;
                AccountNameTextBox.Text = string.Empty;
                PasswordTextBox.Text = string.Empty;
                ConfirmPasswordTextBox.Text = string.Empty;

                Enabled = !Enabled;
                Visible = !Visible;
            }
        }

        private void RegisterBox_Load(object sender, EventArgs e)
        {
            EmailBox.KeyDown += GmailBox_KeyDown;
            EmailBox.Text = string.Empty;

            AccountNameTextBox.KeyDown += AccountNameTextBox_KeyDown;
            AccountNameTextBox.Text = string.Empty;

            PasswordTextBox.KeyDown += PasswordTextBox_KeyDown;
            PasswordTextBox.Text = string.Empty; 

            ConfirmPasswordTextBox.KeyDown += ConfirmPasswordTextBox_KeyDown;
            ConfirmPasswordTextBox.Text = string.Empty; 
        }

        private void AccountNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            var isCaps = IsKeyLocked(Keys.CapsLock);

            AccountNameCapsLockLabel.Enabled = isCaps;
            AccountNameCapsLockLabel.Visible = isCaps;
        }

        private void PasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            var isCaps = IsKeyLocked(Keys.CapsLock);

            PasswordCapsLockLabel.Enabled = isCaps;
            PasswordCapsLockLabel.Visible = isCaps;
        }

        private void ConfirmPasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            var isCaps = IsKeyLocked(Keys.CapsLock);

            ConfirmPasswordCapsLockLabel.Enabled = isCaps;
            ConfirmPasswordCapsLockLabel.Visible = isCaps;
        }
        
        private void GmailBox_KeyDown(object sender, KeyEventArgs e)
        {
            var isCaps = IsKeyLocked(Keys.CapsLock);

            confirmEmailCapsLabel.Enabled = isCaps;
            confirmEmailCapsLabel.Visible = isCaps;
        }

        private void RegisterCreateButton_Click(object sender, EventArgs e)
            => NetworkClient.SendPacket(new Register()
            {
                Email = EmailBox.Text.ToLower(),
                Name = AccountNameTextBox.Text,
                Password = PasswordTextBox.Text,
                ConfirmPassword = ConfirmPasswordTextBox.Text
            });

        private void RegisterCancelButton_Click(object sender, EventArgs e)
        {
            EmailBox.Text = string.Empty;
            AccountNameTextBox.Text = string.Empty;
            PasswordTextBox.Text = string.Empty;
            ConfirmPasswordTextBox.Text = string.Empty;

            Toggle();

            ((MainMenu)Parent).OnBoxClose();
        }
    }
}