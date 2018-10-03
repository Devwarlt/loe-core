using System;
using System.Windows.Forms;

namespace LoESoft.Launcher.Controls.AccountDisplay.Control.Login
{
    public partial class LoginControl : UserControl
    {
        public LoginControl()
        {
            InitializeComponent();
        }

        private void LoginControl_Load(object sender, EventArgs e)
        {
            // Hide the rest of boxes.
            LoginBox.Visible = false;
            LoginBox.Enabled = false;

            SetPopUpBoxVisibility(false);
        }

        public void ToggleLoginBox()
        {
            LoginBox.Visible = !LoginBox.Visible;
            LoginBox.Enabled = !LoginBox.Enabled;
        }

        public void ToggleUI()
        {
            Visible = false;
            Enabled = false;

            ((Main)Parent).ToggleButtons();
        }

        public void SetPopUpBoxVisibility(bool visible) => PopUpBox.Visible = visible;

        public void UpdatePopUp(PopUpSettings settings)
        {
            PopUpBox.Settings = settings;
            PopUpBox.LoadSettings();
        }
    }
}
