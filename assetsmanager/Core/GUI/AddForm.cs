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
            Visible = false;

            var newxmlform = new AddXmlForm() { Manager = Manager };
            newxmlform.ShowDialog();

            if (newxmlform.DialogResult == DialogResult.OK)
                Close();
            else
                Visible = true;
        }

        private void AddItem_Click(object sender, EventArgs e)
        {
            Visible = false;

            var newitemform = new AddItemForm() { Manager = Manager };
            newitemform.ShowDialog();

            if (newitemform.DialogResult == DialogResult.OK)
                Close();
            else
                Visible = true;
        }
    }
}