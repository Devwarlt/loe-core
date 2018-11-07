using LoESoft.Client.Assets.Xml.Structure;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Xml.XPath;
using static LoESoft.Client.Assets.Xml.Structure.XmlContent;

namespace LoESoft.Client.Assets
{
    public static class XmlLibrary
    {
        public static Dictionary<int, ObjectsContent> ObjectsXml = new Dictionary<int, ObjectsContent>();
        public static Dictionary<int, ItemsContent> ItemsXml = new Dictionary<int, ItemsContent>();
        public static Dictionary<int, TilesContent> TilesXml = new Dictionary<int, TilesContent>();

        public static void Init()
        {
            LoadContent("Players");
            LoadContent("Tiles");
            LoadContent("TestObjects");
        }

        private static void LoadContent(string name)
        {
            //process through the xml file...
            foreach (var elem in XmlLoader.LoadAsset(name).XPathSelectElements("//Object"))
            {
                XmlContent content;

                switch ((ContentType) int.Parse(elem.Attribute("type").Value))
                {
                    case ContentType.Objects:
                        {
                            content = new ObjectsContent(elem);
                            ObjectsXml.Add(content.Id, (ObjectsContent) content);
                        }
                        break;

                    case ContentType.Items:
                        {
                            content = new ItemsContent(elem);
                            ItemsXml.Add(content.Id, (ItemsContent) content);
                        }
                        break;

                    case ContentType.Tiles:
                        {
                            content = new TilesContent(elem);
                            TilesXml.Add(content.Id, (TilesContent) content);
                        }
                        break;
                }
            }
        }

        public static Texture2D GetSpriteFromContent(XmlContent content)
        {
            var spriteSet = AssetLibrary.Sprites[content.Texture.FileName];

            return spriteSet.GetSprite(content.Texture.ImageIndex.Item1, content.Texture.ImageIndex.Item2);
        }

        public static List<Texture2D> GetObjectAnimation(XmlContent content)
        {
            var spriteSet = AssetLibrary.Sprites[content.Texture.FileName];

            return spriteSet.GetSpritesByWidth(content.Texture.ImageIndex.Item2);
        }

        public static Dictionary<int, List<Texture2D>> GetPlayerAnimation(XmlContent content)
        {
            var spriteSet = AssetLibrary.Sprites[content.Texture.FileName];
            var yOffset = (content.Texture.ImageIndex.Item2 * 4);

            var offSetList = new List<int>();

            offSetList.Add(yOffset);
            offSetList.Add(yOffset + 1);
            offSetList.Add(yOffset + 2);
            offSetList.Add(yOffset + 3);
            
            var dictionary = new Dictionary<int, List<Texture2D>>();
            int idx = 0;

            foreach (var i in offSetList)
            {
                var tempList = new List<Texture2D>();

                foreach (var y in spriteSet.GetSpritesByWidth(i))
                    tempList.Add(y);

                dictionary.Add(idx, tempList);
                idx++;
            }

            return dictionary;
        }
    }
}