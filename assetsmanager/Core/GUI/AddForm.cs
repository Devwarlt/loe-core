using System;
using System.Windows.Forms;

namespace LoESoft.AssetsManager.Core.GUI
{
    public partial class AddForm : Form
    {
        public Manager Manager { get; set; }

        public AddForm() => InitializeComponent();

        private void AddXml_Click(object sender, EventArgs e)
        {
            var newxmlform = new AddXmlForm() { Manager = Manager };
            newxmlform.ShowDialog();

            if (newxmlform.DialogResult == DialogResult.OK)
                Close();
        }
    }
}