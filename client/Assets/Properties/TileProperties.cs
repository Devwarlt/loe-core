using System.Xml.Linq;

namespace LoESoft.Client.Assets.Properties
{
    public class TileProperties
    {
        public bool NotWalkbale { get; set; }

        public TileProperties(XElement elem)
        {
            NotWalkbale = elem.Element("NoWalk") != null;
        }
    }
}
