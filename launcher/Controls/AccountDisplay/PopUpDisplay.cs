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

        public PopUpSettings Settings { get; set; }

        public void LoadSettings()
        {
            PopUpTitle.Text = Settings.Title;
            PopUpContent.Text = Settings.Content;
            Settings.ExtraAction?.Invoke();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Settings.Action?.Invoke();
            Visible = !Visible;
        }
    }
}
