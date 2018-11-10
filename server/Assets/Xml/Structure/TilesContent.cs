using System.Xml.Linq;

namespace LoESoft.Server.Assets.Xml.Structure
{
    public class TilesContent : XmlContent
    {
        public bool Walkable { get; set; }

        public TilesContent(XElement elem) : base(elem)
        {
            Walkable = elem.Element("UnWalkable") != null;
        }
    }
}