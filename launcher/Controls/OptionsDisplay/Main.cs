using System;
using System.Windows.Forms;

namespace LoESoft.Launcher.Controls.OptionsDisplay
{
    public partial class Main : UserControl
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (!Enabled)
                return;

            SaveButton.Enabled = false;

            AutoLoginCheckBox.Checked = Convert.ToBoolean(Settings.LauncherSettings.AutoLogin ?? "True");
            AutoUpdateCheckBox.Checked = Convert.ToBoolean(Settings.LauncherSettings.AutoUpdate ?? "True");
            AutoOffersCheckBox.Checked = Convert.ToBoolean(Settings.LauncherSettings.AutoOffers ?? "True");
            AutoNewsCheckBox.Checked = Convert.ToBoolean(Settings.LauncherSettings.AutoNews ?? "True");

            AutoLoginCheckBox.Click += delegate { SaveButton.Enabled = true; };
            AutoUpdateCheckBox.Click += delegate { SaveButton.Enabled = true; };
            AutoOffersCheckBox.Click += delegate { SaveButton.Enabled = true; };
            AutoNewsCheckBox.Click += delegate { SaveButton.Enabled = true; };
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Settings.LauncherSettings.AutoLogin = AutoLoginCheckBox.Checked.ToString();
            Settings.LauncherSettings.AutoUpdate = AutoUpdateCheckBox.Checked.ToString();
            Settings.LauncherSettings.AutoOffers = AutoOffersCheckBox.Checked.ToString();
            Settings.LauncherSettings.AutoNews = AutoNewsCheckBox.Checked.ToString();
            Settings.LauncherSettings.SaveSettings();

            SaveButton.Enabled = false;
        }
    }
}