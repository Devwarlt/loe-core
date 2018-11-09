using System;
using System.Windows.Forms;

namespace LoESoft.Client.Core.GUI.MainScreen
{
    public partial class PopUp : UserControl
    {
        public PopUp() => InitializeComponent();

        public PopUpSettings Settings { get; set; }

        public void SetSubmit(bool enabled) => SubmitButton.Enabled = enabled;

        public void LoadSettings()
        {
            Settings.OnDisplay?.Invoke();
            Title.Text = Settings.Title;
            Content.Text = Settings.Content;
            Content.TextAlign = Settings.Alignment;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            Settings.OnClose?.Invoke();
            Visible = !Visible;
        }
    }
}