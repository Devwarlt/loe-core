using System;
using System.Windows.Forms;

namespace LoESoft.Launcher.Controls.AccountDisplay
{
    public partial class PopUpDisplay : UserControl
    {
        public PopUpDisplay()
        {
            InitializeComponent();
        }

        public void SetTitle(string titleText) => PopUpTitle.Text = titleText;

        public void SetText(string contentText) => PopUpText.Text = contentText;

        private void OkButton_Click(object sender, EventArgs e)
        {
            ((AccountDisplayControl)Parent).ClickToggle();
            Visible = !Visible;
        }
    }
}
