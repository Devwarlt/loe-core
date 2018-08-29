using LoESoft.Launcher.Controls;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace LoESoft.Launcher
{
    public partial class LauncherForm : Form
    {
        public ExtendedButton SelectedDisplay { get; set; }

        public LauncherForm()
        {
            InitializeComponent();

            SelectedDisplay = HomeButton;
        }

        private void ChangeButtonSelected(object sender, EventArgs e)
        {
            var button = (ExtendedButton)sender;

            ButtonSelectedDisplay.Height = button.Height;
            ButtonSelectedDisplay.Top = button.Top;

            SelectedDisplay.SetInActive();
            SelectedDisplay = button;
            SelectedDisplay.SetActive();
        }
    }
}
