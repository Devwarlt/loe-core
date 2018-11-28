using System.Xml.Linq;

namespace LoESoft.AssetsManager.Core.Assets.Structure
{
    public class XmlFile
    {
        public string File { get; set; }
        public string Size { get; set; }
        public string Path { get; set; }
        public XElement XElement { get; set; }
    }
}