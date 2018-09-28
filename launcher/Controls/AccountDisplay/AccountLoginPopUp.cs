using System;
using System.Windows.Forms;

namespace LoESoft.Launcher.Controls.AccountDisplay
{
    public partial class AccountLoginPopUp : UserControl
    {
        public AccountLoginPopUp()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e) { }

        private void IsKeyDown(object sender, KeyEventArgs e)
        {
            var isCaps = IsKeyLocked(Keys.CapsLock);

            CapsLockLabel.Enabled = isCaps;
            CapsLockLabel.Visible = isCaps;
        }

        private void TitleLabel_Click(object sender, EventArgs e) { }

        private void CloseRegisterButton_Click(object sender, EventArgs e) => ((AccountDisplayControl)Parent).RegisterToggle();
    }
}
