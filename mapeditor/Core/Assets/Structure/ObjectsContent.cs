using System.Xml.Linq;

namespace LoESoft.MapEditor.Core.Assets.Structure
{
    public class ObjectsContent : XmlContent
    {
        public bool Blocked { get; set; }

        public ObjectsContent(XElement elem) : base(elem)
        {
            Blocked = elem.Element("Blocked") != null;
        }
    }
}