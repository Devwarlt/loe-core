using System;
using System.Windows.Forms;

namespace LoESoft.Launcher.Controls.AccountDisplay
{
    public partial class PopUpBox : UserControl
    {
        public PopUpBox()
        {
            InitializeComponent();
        }

        public PopUpSettings Settings { get; set; }

        public void LoadSettings()
        {
            PopUpTitle.Text = Settings.Title;
            PopUpContent.Text = Settings.Content;
            Settings.OnDisplay?.Invoke();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Settings.OnClose?.Invoke();
            Visible = !Visible;
        }
    }
}
