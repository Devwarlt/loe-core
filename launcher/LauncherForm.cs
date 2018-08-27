using System;
using System.Windows.Forms;

namespace LoESoft.Launcher
{
    public partial class LauncherForm : Form
    {
        public LauncherForm()
        {
            InitializeComponent();
        }

        private void ChangeButtonSelected(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (!button.Enabled)
                return;

            ButtonSelectedDisplay.Height = button.Height;
            ButtonSelectedDisplay.Top = button.Top;
        }
    }
}
