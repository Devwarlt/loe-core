using System;
using System.Windows.Forms;

namespace LoESoft.Launcher.Controls.AccountDisplay.Control.Update
{
    public partial class UpdateBox : UserControl
    {
        public UpdateBox()
        {
            InitializeComponent();
        }

        private void UpdateOKButton_Click(object sender, EventArgs e)
        {
            var parent = (UpdateControl)Parent;
            parent.ToggleUpdateBox();
            parent.ToggleUpdateMediator();
        }

        private void UpdateCancelButton_Click(object sender, EventArgs e)
        {
            UpdateLabel.Text = null;

            var parent = (UpdateControl)Parent;
            parent.ToggleUpdateBox();
            parent.ToggleUI();
        }

        public void SetContent()
        {
        }// => UpdateLabel.Text = ((UpdateControl)Parent).UpdateText;
    }
}