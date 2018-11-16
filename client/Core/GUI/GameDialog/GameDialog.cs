using System;
using System.Windows.Forms;

namespace LoESoft.Client.Core.GUI.GameDialog
{
    public partial class GameDialog : UserControl
    {
        public GameDialogSettings Settings { get; set; }

        private LoadDelegate OnDialogLoad { get; set; }
        private SubmitDelegate OnDialogSubmit { get; set; }

        private delegate void LoadDelegate();

        private delegate void SubmitDelegate(object sender, EventArgs e);

        public GameDialog()
        {
            InitializeComponent();

            OnDialogLoad = () => LoadSettings();
            OnDialogSubmit = (sender, e) => SubmitButton_Click(sender, e);
        }

        public void LoadSettings()
        {
            if (InvokeRequired)
                Invoke(OnDialogLoad);
            else
            {
                Settings.OnDisplay?.Invoke();
                Title.Text = Settings.Title;
                Content.Text = Settings.Content;
                Content.TextAlign = Settings.Alignment;
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (InvokeRequired)
                Invoke(OnDialogSubmit, new object[] { sender, e });
            else
            {
                Settings.OnClose?.Invoke();
                Visible = !Visible;
            }
        }
    }
}