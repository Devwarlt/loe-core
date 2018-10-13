using System;
using System.Windows.Forms;

namespace LoESoft.Launcher.Controls.AccountDisplay.Control.Update
{
    public partial class UpdateControl : UserControl
    {
        public UpdateControl()
        {
            InitializeComponent();
        }

        private void UpdateControl_Load(object sender, EventArgs e)
        {
            if (!Enabled)
                return;

            UpdateBox.Visible = false;
            UpdateBox.Enabled = false;

            UpdateMediator.Visible = false;
            UpdateMediator.Enabled = false;

            SetPopUpBoxVisibility(false);
        }

        public void ToggleUpdateBox()
        {
            UpdateBox.Visible = !UpdateBox.Visible;
            UpdateBox.Enabled = !UpdateBox.Enabled;
        }

        public void ToggleUpdateMediator()
        {
            UpdateMediator.Visible = !UpdateMediator.Visible;
            UpdateMediator.Enabled = !UpdateMediator.Enabled;
        }

        public void ToggleUI()
        {
            Visible = false;
            Enabled = false;

            ((Main)Parent).BackToMenu(true);
        }

        public void SetPopUpBoxVisibility(bool visible) => PopUpBox.Visible = visible;

        public void UpdatePopUp(PopUpSettings settings)
        {
            PopUpBox.Settings = settings;
            PopUpBox.LoadSettings();
        }
    }
}
