using System;
using System.Windows.Forms;

namespace LoESoft.Launcher.Controls.AccountDisplay
{
    public partial class LoginRegisterDisplay : UserControl
    {
        public LoginRegisterDisplay()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            // temp until implementing registering
            ((AccountDisplayControl)Parent).RegisterToggle();
        }

        private void IsKeyDown(object sender, KeyEventArgs e)
        {
            var isCaps = IsKeyLocked(Keys.CapsLock);

            CapsLockLabel.Enabled = isCaps;
            CapsLockLabel.Visible = isCaps;
        }

        private void TitleLabel_Click(object sender, EventArgs e) { }
    }
}
