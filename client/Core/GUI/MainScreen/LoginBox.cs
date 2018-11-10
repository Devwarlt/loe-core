using LoESoft.Client.Core.Networking.Packets.Outgoing;
using System;
using System.Windows.Forms;

namespace LoESoft.Client.Core.GUI.MainScreen
{
    public partial class LoginBox : UserControl
    {
        public LoginBox()
        {
            InitializeComponent();

            Enabled = false;
            Visible = false;
        }

        public void Toggle()
        {
            Enabled = !Enabled;
            Visible = !Visible;
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
        {
            var gameuser = ((MainMenu)Parent).GameUser;
            gameuser.SendPacket(new Login()
            {
                Name = AccountNameTextBox.Text,
                Password = PasswordTextBox.Text
            });

            LoginCancelButton_Click(null, null);
        }

        private void LoginCancelButton_Click(object sender, EventArgs e) => ((MainMenu)Parent).OnLoginBoxClose();
    }
}