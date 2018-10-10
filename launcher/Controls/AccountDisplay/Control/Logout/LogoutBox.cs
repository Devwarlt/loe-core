using System;
using System.Windows.Forms;

namespace LoESoft.Launcher.Controls.AccountDisplay.Control.Logout
{
    public partial class LogoutBox : UserControl
    {
        public LogoutBox()
        {
            InitializeComponent();
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            Account.UserAccount.Invalidate();

            LogoutCancelButton_Click(null, null);
        }

        private void LogoutCancelButton_Click(object sender, EventArgs e)
        {
            var parent = ((LogoutControl)Parent);
            parent.ToggleLogoutBox();
            parent.ToggleUI();

            if (sender == null && e == null)
                parent.UpdateLabels();
        }
    }
}
