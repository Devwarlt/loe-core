using System.Xml.Linq;

namespace LoESoft.Client.Assets.Properties
{
    public class TileProperties
    {
        public int TextureIndex { get; set; }
        public string TextureFile { get; set; }

        public TileProperties(XElement elem)
        {
            TextureIndex = int.Parse(elem.Element("Texture").Attribute("index").Value);
            TextureFile = elem.Element("Texture").Value;
        }
    }
}