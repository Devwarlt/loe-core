using LoESoft.MapEditor.Core.Assets.Structure;
using System.Collections.Generic;
using System.Xml.XPath;
using static LoESoft.MapEditor.Core.Assets.Structure.XmlContent;

namespace LoESoft.MapEditor.Core.Assets
{
    public static class XmlLibrary
    {
        public static Dictionary<int, ObjectsContent> ObjectsXml = new Dictionary<int, ObjectsContent>();
        public static Dictionary<int, ItemsContent> ItemsXml = new Dictionary<int, ItemsContent>();
        public static Dictionary<int, TilesContent> TilesXml = new Dictionary<int, TilesContent>();

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