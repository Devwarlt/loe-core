using LoESoft.AssetsManager.Core.Assets;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LoESoft.AssetsManager.Core.GUI
{
    public partial class AddXmlForm : Form
    {
        public Manager Manager { get; set; }

        public AddXmlForm() => InitializeComponent();

        private void XmlName_TextChanged(object sender, EventArgs e)
        {
            var exist = XmlLibrary.Xmls.ContainsKey(XmlName.Text);

            if (string.IsNullOrWhiteSpace(XmlName.Text))
                exist = true;

            SaveButton.Enabled = !exist;
            SaveButton.Image = !exist ? Properties.Resources.hud_check : Properties.Resources.hud_check_inactive;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            XmlLibrary.Xmls.Add(XmlName.Text, new KeyValuePair<string, XElement>("<new>", null));
            Manager.UpdateXmlPanel(-1, XmlName.Text);

            DialogResult = DialogResult.OK;

            Close();
        }
    }
}