using LoESoft.AssetsManager.Core.Assets.Structure;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using static LoESoft.AssetsManager.Core.Assets.Structure.XmlContent;

namespace LoESoft.AssetsManager.Core.Assets
{
    public static class XmlLibrary
    {
        public static Dictionary<string, KeyValuePair<string, XElement>> Xmls = new Dictionary<string, KeyValuePair<string, XElement>>();
        public static Dictionary<int, ObjectsContent> ObjectsXml = new Dictionary<int, ObjectsContent>();
        public static Dictionary<int, ItemsContent> ItemsXml = new Dictionary<int, ItemsContent>();
        public static Dictionary<int, TilesContent> TilesXml = new Dictionary<int, TilesContent>();

        public static void Init(List<XmlFile> xmls)
        {
            foreach (var xml in xmls)
                if (!Xmls.ContainsKey(xml.File))
                    Xmls.Add(xml.File, new KeyValuePair<string, XElement>(xml.Size, xml.XElement));

            LoadContents(xmls.Select(xml => xml.XElement).ToList());

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
                        case ContentType.Objects:
                            {
                                if (!ObjectsXml.ContainsKey(content.Id))
                                    ObjectsXml.Add(content.Id, new ObjectsContent(elem));
                            }
                            break;

                        case ContentType.Items:
                            {
                                if (!ItemsXml.ContainsKey(content.Id))
                                    ItemsXml.Add(content.Id, new ItemsContent(elem));
                            }
                            break;

                        case ContentType.Tiles:
                            {
                                if (!TilesXml.ContainsKey(content.Id))
                                    TilesXml.Add(content.Id, new TilesContent(elem));
                            }
                            break;
                    }
                }
        }
    }
}