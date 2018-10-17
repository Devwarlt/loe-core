using System;
using System.Windows.Forms;

namespace LoESoft.Launcher.Controls.AccountDisplay.Control.Updater
{
    public partial class UpdaterControl : UserControl
    {
        // [ok] TODO: implement UpdateBox and UpdateControl, with following features below:
        // Update running App:
        // https://visualstudiomagazine.com/articles/2017/12/15/replace-running-app.aspx
        // ZIP:
        // https://stackoverflow.com/questions/16052877/how-to-unzip-all-zip-file-from-folder-using-c-sharp-4-0-and-without-using-any-o
        // https://stackoverflow.com/questions/22133053/how-to-extract-just-the-specific-directory-from-a-zip-archive-in-c-sharp-net-4
        // https://www.youtube.com/watch?v=BH9-H-b41Ys
        // https://www.youtube.com/watch?v=aE_Wl4Pouso
        // https://www.youtube.com/watch?v=NGNQOWjkI_Y
        // https://www.youtube.com/watch?v=KZr3KI2BbyE

        public string UpdateText { get; private set; }
        public string UpdateLink { get; private set; }

        public UpdaterControl()
        {
            InitializeComponent();
        }

        private void UpdaterControl_Load(object sender, EventArgs e)
        {
            // Hide the rest of boxes.
            UpdaterBox.Visible = false;
            UpdaterBox.Enabled = false;

            SetPopUpBoxVisibility(false);
        }

        public void ToggleUpdaterBox()
        {
            UpdaterBox.Visible = !UpdaterBox.Visible;
            UpdaterBox.Enabled = !UpdaterBox.Enabled;
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

        public void GetUpdateInfo(string content)
        {
            var data = content.Split('|');
            UpdateText = data[0].Replace("|", string.Empty);
            UpdateLink = data[1].Replace("|", string.Empty);

            UpdaterBox.SetContent(UpdateText);
        }
    }
}
