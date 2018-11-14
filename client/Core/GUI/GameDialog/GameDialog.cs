using System;
using System.Windows.Forms;

namespace LoESoft.Client.Core.GUI.GameDialog
{
    public partial class GameDialog : UserControl
    {
        public GameDialogSettings Settings { get; set; }

        public GameDialog() => InitializeComponent();

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