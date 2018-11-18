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
                AccountNameTextBox.Text = null;
                PasswordTextBox.Text = null;

                Enabled = !Enabled;
                Visible = !Visible;
            }
        }

        private void RegisterBox_Load(object sender, EventArgs e)
        {
            AccountNameTextBox.KeyDown += AccountNameTextBox_KeyDown;
            AccountNameTextBox.Text = null;

            PasswordTextBox.KeyDown += PasswordTextBox_KeyDown;
            PasswordTextBox.Text = null;

            ConfirmPasswordTextBox.KeyDown += ConfirmPasswordTextBox_KeyDown;
            ConfirmPasswordTextBox.Text = null;
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

        private void RegisterCreateButton_Click(object sender, EventArgs e)
            => ((MainMenu)Parent).GameUser.SendPacket(new Register()
            {
                Name = AccountNameTextBox.Text,
                Password = PasswordTextBox.Text,
                ConfirmPassword = ConfirmPasswordTextBox.Text
            });

        private void RegisterCancelButton_Click(object sender, EventArgs e)
        {
            AccountNameTextBox.Text = null;
            PasswordTextBox.Text = null;
            ConfirmPasswordTextBox.Text = null;

            Toggle();

            ((MainMenu)Parent).OnBoxClose();
        }
    }
}