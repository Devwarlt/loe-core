using System.Collections.Generic;
using System.Xml.Linq;

namespace LoESoft.Client.Assets.Properties
{
    public static class TileLibrary
    {
        public static Dictionary<int, XElement> XmlLibrary { get; set; }
        public static Dictionary<int, TileProperties> PropsLibrary { get; set; }
        public static Dictionary<int, string> TypeToId { get; set; }
        public static Dictionary<string, int> IdToType { get; set; }

        public static void Load(string assetName)
        {
            if (XmlLibrary == null)
                XmlLibrary = new Dictionary<int, XElement>();
            if (PropsLibrary == null)
                PropsLibrary = new Dictionary<int, TileProperties>();
            if (TypeToId == null)
                TypeToId = new Dictionary<int, string>();
            if (IdToType == null)
                IdToType = new Dictionary<string, int>();

            var elems = XmlLoader.LoadAsset(assetName);

            foreach (var elem in elems.Elements())
            {
                var type = int.Parse(elem.Attribute("type").Value);
                var id = elem.Attribute("id").Value;

                XmlLibrary.Add(type, elem);
                PropsLibrary.Add(type, new TileProperties(elem));
                TypeToId.Add(type, id);
                IdToType.Add(id, type);
            }
        }
    }
}