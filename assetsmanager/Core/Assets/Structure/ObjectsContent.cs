using System.Xml.Linq;

namespace LoESoft.AssetsManager.Core.Assets.Structure
{
    public class ObjectsContent : XmlContent
    {
        public bool Blocked { get; set; }

        public ObjectsContent()
        {
        }

        public ObjectsContent(XElement elem) : base(elem) => Blocked = elem.Element("Blocked") != null;
    }
}