using LoESoft.MapEditor.Core.Assets.Structure;
using LoESoft.MapEditor.Core.Util;
using System.Collections.Generic;
using System.Xml.XPath;
using static LoESoft.MapEditor.Core.Assets.Structure.XmlContent;

namespace LoESoft.MapEditor.Core.Assets
{
    public static class XmlLibrary
    {
        public static Dictionary<int, InteractiveObject> AllXmls = new Dictionary<int, InteractiveObject>();
        public static Dictionary<int, ObjectsContent> ObjectsXml = new Dictionary<int, ObjectsContent>();
        public static Dictionary<int, ItemsContent> ItemsXml = new Dictionary<int, ItemsContent>();
        public static Dictionary<int, TilesContent> TilesXml = new Dictionary<int, TilesContent>();

        public static void Init()
        {
            App.Info("Loading embedded files...");

            LoadContents();
            DisplayFormattedAmount(AllXmls, "element", "elements");
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
                    var content = new XmlContent(elem);

                    AllXmls.Add(content.Id, new InteractiveObject()
                    {
                        Id = content.Id,
                        Name = content.Name,
                        Type = content.Type,
                        LayerData = content.LayerData,
                        TextureData = content.TextureData
                    });

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