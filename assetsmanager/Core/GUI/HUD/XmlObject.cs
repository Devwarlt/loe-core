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

        public List<SpritePallete> Palletes { get; private set; }

        public XmlObject() => InitializeComponent();

        public void SetFileName(string name) => FileNameLabel.Text = name;

        public void SetFileSize(string size) => FileSizeLabel.Text = size;

        public void SetSpritePalletes(List<SpritePallete> palletes) => Palletes = palletes;

        private void XmlIcon_DoubleClick(object sender, EventArgs e) => Action?.Invoke();
    }
}