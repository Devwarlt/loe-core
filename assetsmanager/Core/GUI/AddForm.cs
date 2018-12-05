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
            var newxmlform = new AddXmlForm();
            newxmlform.ShowDialog();

            if (newxmlform.DialogResult == DialogResult.OK)
            {
                Manager.AddOrRemoveXml(-1, newxmlform.Xml);

                Close();
            }
        }

        private void AddItem_Click(object sender, EventArgs e)
        {
            var newitemform = new AddItemForm();
            newitemform.ShowDialog();

            if (newitemform.DialogResult == DialogResult.OK)
            {
                Manager.RefreshXmls();

                Close();
            }
        }
    }
}