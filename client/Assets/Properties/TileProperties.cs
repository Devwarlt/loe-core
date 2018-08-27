using System.Xml.Linq;

namespace LoESoft.Client.Assets.Properties
{
    public class TileProperties
    {
        public int TextureIndex { get; set; }
        public string TextureFile { get; set; }

        public TileProperties(XElement elem)
        {
            var texture = elem.Element("Texture");
            TextureIndex = int.Parse(texture.Attribute("index").Value);
            TextureFile = texture.Value;
        }
    }
}
