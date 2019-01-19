using LoESoft.Client.Core.Networking;
using LoESoft.Client.Core.Networking.Packets.Outgoing;
using System;
using System.Windows.Forms;

namespace LoESoft.Client.Core.GUI.MainScreen
{
    public partial class LoginBox : UserControl
    {
        private ToggleDelegate OnToggle { get; set; }

        private delegate void ToggleDelegate();

        public LoginBox()
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

        private void LoginBox_Load(object sender, EventArgs e)
        {
            AccountNameTextBox.KeyDown += AccountNameTextBox_KeyDown;
            PasswordTextBox.KeyDown += PasswordTextBox_KeyDown;
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

        private void LoginOKButton_Click(object sender, EventArgs e)
            => NetworkClient.SendPacket(new Login()
            {
                Email = AccountNameTextBox.Text.ToLower(),
                Password = PasswordTextBox.Text
            });

        private void LoginCancelButton_Click(object sender, EventArgs e)
        {
            Toggle();

            ((MainMenu)Parent).OnBoxClose();
        }
    }
}