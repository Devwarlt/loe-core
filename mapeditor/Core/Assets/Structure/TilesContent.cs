using System.Xml.Linq;

namespace LoESoft.MapEditor.Core.Assets.Structure
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