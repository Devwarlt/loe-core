using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LoESoft.AssetsManager.Core.GUI.HUD
{
    public partial class XmlObject : UserControl
    {
        public int Id { get; set; }
        public XElement XmlContent { get; set; }
        public Action Action { get; set; }

        public string FileName
        {
            get => FileNameLabel.Text;
            set => FileNameLabel.Text = value;
        }

        public string FileSize
        {
            get => FileSizeLabel.Text;
            set => FileSizeLabel.Text = value;
        }

        public List<SpritePallete> Palletes { get; set; }

        public XmlObject() => InitializeComponent();

        private void XmlIcon_Click(object sender, EventArgs e) => Action?.Invoke();

        private void RemoveXmlIcon_Click(object sender, EventArgs e)
        {
            var box = MessageBox.Show($"Do you want to remove '{FileNameLabel.Text}' XML file?", "Confirm delete action", MessageBoxButtons.YesNo);

            if (box == DialogResult.Yes)
                ((Manager)Parent.Parent.Parent.Parent).AddOrRemoveXml(Id);
        }
    }
}