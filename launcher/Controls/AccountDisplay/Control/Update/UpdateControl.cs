using System;
using System.Windows.Forms;

namespace LoESoft.Launcher.Controls.AccountDisplay.Control.Update
{
    public partial class UpdateControl : UserControl
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

        public UpdateControl()
        {
            InitializeComponent();
        }

        private void UpdateControl_Load(object sender, EventArgs e)
        {
            if (!Enabled)
                return;

            // Hide the rest of boxes.
            UpdateBox.Visible = false;
            UpdateBox.Enabled = false;

            //UpdateMediator.Visible = false;
            //UpdateMediator.Enabled = false;

            //SetPopUpBoxVisibility(false);
        }

        public void GetUpdateInfo(string content)
        {
            var data = content.Split('|');
            UpdateText = data[0].Replace("|", string.Empty);
            UpdateLink = data[1].Replace("|", string.Empty);
        }

        public void SetUpdateBoxContent() => UpdateBox.SetContent();

        public void ToggleUpdateBox()
        {
            UpdateBox.Visible = !UpdateBox.Visible;
            UpdateBox.Enabled = !UpdateBox.Enabled;
        }

        public void ToggleUpdateMediator()
        {
            //UpdateMediator.Visible = !UpdateMediator.Visible;
            //UpdateMediator.Enabled = !UpdateMediator.Enabled;
        }

        public void ToggleUI()
        {
            Visible = false;
            Enabled = false;

            ((Main)Parent).BackToMenu(true);
        }

        public void SetPopUpBoxVisibility(bool visible) { } //=> PopUpBox.Visible = visible;

        public void UpdatePopUp(PopUpSettings settings)
        {
            //PopUpBox.Settings = settings;
            //PopUpBox.LoadSettings();
        }
    }
}
