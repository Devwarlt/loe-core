using System;
using System.Windows.Forms;

namespace LoESoft.Launcher.Controls.AccountDisplay.Control.Logout
{
    public partial class LogoutControl : UserControl
    {
        public LogoutControl()
        {
            InitializeComponent();
        }

        private void LoginControl_Load(object sender, EventArgs e)
        {
            // Hide the rest of boxes.
            LogoutBox.Visible = false;
            LogoutBox.Enabled = false;
        }

        public void ToggleLogoutBox()
        {
            LogoutBox.Visible = !LogoutBox.Visible;
            LogoutBox.Enabled = !LogoutBox.Enabled;
        }

        public void ToggleUI()
        {
            Visible = false;
            Enabled = false;

            ((Main)Parent).ToggleButtons();
        }

        public void UpdateLabels() => ((Main)Parent).DispatchLogin(this, new Tuple<bool, bool>(false, false));
    }
}