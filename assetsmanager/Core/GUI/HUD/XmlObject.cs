using System.Windows.Forms;

namespace LoESoft.AssetsManager.Core.GUI.HUD
{
    public partial class XmlObject : UserControl
    {
        public XmlObject() => InitializeComponent();

        public void SetFileName(string name) => FileNameLabel.Text = name;

        public void SetFileSize(string size) => FileSizeLabel.Text = size;
    }
}