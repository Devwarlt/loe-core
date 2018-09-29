using System;
using System.Windows.Forms;

namespace LoESoft.Launcher.Controls.AccountDisplay
{
    public partial class CurrentAcccountDisplay : UserControl
    {
        public CurrentAcccountDisplay()
        {
            InitializeComponent();
        }

        private void LogOutButton_Click(object sender, EventArgs e) => ((AccountDisplayControl)Parent).RegisterToggle();
    }
}
