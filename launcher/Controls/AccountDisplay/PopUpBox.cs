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
            Title.Text = Settings.Title;
            Content.Text = Settings.Content;
            Content.TextAlign = Settings.Alignment;
            Settings.OnDisplay?.Invoke();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            Settings.OnClose?.Invoke();
            Visible = !Visible;
        }
    }
}
