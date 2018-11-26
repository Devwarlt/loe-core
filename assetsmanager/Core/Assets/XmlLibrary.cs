using LoESoft.AssetsManager.Core.Assets.Structure;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.XPath;
using static LoESoft.AssetsManager.Core.Assets.Structure.XmlContent;

namespace LoESoft.AssetsManager.Core.Assets
{
    public static class XmlLibrary
    {
        public static Dictionary<int, ObjectsContent> ObjectsXml = new Dictionary<int, ObjectsContent>();
        public static Dictionary<int, ItemsContent> ItemsXml = new Dictionary<int, ItemsContent>();
        public static Dictionary<int, TilesContent> TilesXml = new Dictionary<int, TilesContent>();

        public static void Init(List<XElement> xmls)
        {
            LoadContents(xmls);

            DisplayFormattedAmount(ObjectsXml, "object", "objects");
            DisplayFormattedAmount(ItemsXml, "item", "items");
            DisplayFormattedAmount(TilesXml, "tile", "tiles");
        }

        private static void DisplayFormattedAmount<T>(Dictionary<int, T> data, string singular, string plural)
            => App.Info($"- Loaded {data.Keys.Count} {(data.Keys.Count > 1 ? plural : singular)}.");

        private static void LoadContents(List<XElement> xmls)
        {
            foreach (var xml in xmls)
                foreach (var elem in xml.XPathSelectElements("//Object"))
                {
                    var content = new XmlContent(elem);

                    switch ((ContentType)int.Parse(elem.Attribute("type").Value))
                    {
                        case ContentType.Objects: ObjectsXml.Add(content.Id, new ObjectsContent(elem)); break;

                        case ContentType.Items: ItemsXml.Add(content.Id, new ItemsContent(elem)); break;

                        case ContentType.Tiles: TilesXml.Add(content.Id, new TilesContent(elem)); break;
                    }
                }
        }
    }
}