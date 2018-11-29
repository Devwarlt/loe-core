using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LoESoft.AssetsManager.Core.GUI.HUD
{
    public partial class XmlObject : UserControl
    {
        public int Id { get; set; }
        public XElement XmlContent { get; set; }
        public Action Action { get; set; }

        public XmlObject() => InitializeComponent();

        public void SetFileName(string name) => FileNameLabel.Text = name;

        public void SetFileSize(string size) => FileSizeLabel.Text = size;

        private void XmlIcon_DoubleClick(object sender, EventArgs e) => Action?.Invoke();
    }
}