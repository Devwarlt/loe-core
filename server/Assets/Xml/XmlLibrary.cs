using LoESoft.Server.Assets.Xml.Structure;
using System.Collections.Generic;
using System.Xml.XPath;
using static LoESoft.Server.Assets.Xml.Structure.XmlContent;

namespace LoESoft.Server.Assets.Xml
{
    public static class XmlLibrary
    {
        public static Dictionary<int, IXmlContent> ObjectsXml = new Dictionary<int, IXmlContent>();
        public static Dictionary<int, IXmlContent> ItemsXml = new Dictionary<int, IXmlContent>();
        public static Dictionary<int, IXmlContent> TilesXml = new Dictionary<int, IXmlContent>();

        public static void Init()
        {
            App.Info("Loading embedded files...");

            LoadContents();
            DisplayFormattedAmount(ObjectsXml, "object", "objects");
            DisplayFormattedAmount(ItemsXml, "item", "items");
            DisplayFormattedAmount(TilesXml, "tile", "tiles");

            App.Info("Loading embedded files... OK!");
        }

        private static void DisplayFormattedAmount<T>(Dictionary<int, T> data, string singular, string plural)
            => App.Info($"- Loaded {data.Keys.Count} {(data.Keys.Count > 1 ? plural : singular)}.");

        public static Dictionary<int, IXmlContent> GetXmlsByContentType(ContentType type)
        {
            switch (type)
            {
                case ContentType.Items: return ItemsXml;
                case ContentType.Objects: return ObjectsXml;
                case ContentType.Tiles: return TilesXml;
                default: return null;
            }
        }

        private static void LoadContents()
        {
            foreach (var elements in XmlLoader.GetEmbeddedGameAssets())
                foreach (var elem in elements.XPathSelectElements("//Object"))
                {
                    XmlContent content;

                    switch ((ContentType)int.Parse(elem.Attribute("type").Value))
                    {
                        case ContentType.Objects:
                            {
                                content = new ObjectsContent(elem);
                                ObjectsXml.Add(content.Id, (ObjectsContent)content);
                            }
                            break;

                        case ContentType.Items:
                            {
                                content = new ItemsContent(elem);
                                ItemsXml.Add(content.Id, (ItemsContent)content);
                            }
                            break;

                        case ContentType.Tiles:
                            {
                                content = new TilesContent(elem);
                                TilesXml.Add(content.Id, (TilesContent)content);
                            }
                            break;
                    }
                }
        }
    }
}