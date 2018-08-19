using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.XPath;
using static LoESoft.Client.Assets.Serialization.AssetTypes.Utils.Utils;

namespace LoESoft.Client.Assets.Serialization.AssetTypes
{
    public class Vocation
    {
        public static Dictionary<int, Vocation> _assets = new Dictionary<int, Vocation>();

        public int Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Description { get; set; }
        public AssetTexture AssetTexture { get; set; }

        public static void Load(XElement root)
        {
            foreach (var i in root.XPathSelectElements(AssetSerialization.GetElementByAssetType(AssetType.Vocation)))
            {
                int id = int.Parse(i.Attribute("id").Value);

                XmlReader.XmlsDictionary[id] = i;

                XElement assetTexture = i.Element("Texture");

                _assets[id] = new Vocation()
                {
                    Id = id,
                    Name = i.Attribute("name").Value,
                    Class = i.Element("Class").Value,
                    Description = i.Element("Description").Value,
                    AssetTexture = new AssetTexture()
                    {
                        _textureType = AssetTexture.GetTextureType(assetTexture.Attribute("type").Value),
                        _file = GetInheritData<string>(assetTexture, "File"),
                        _index = GetInheritData<uint>(assetTexture, "Index")
                    }
                };
            }
        }
    }
}
