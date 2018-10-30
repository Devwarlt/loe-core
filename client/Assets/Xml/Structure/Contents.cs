using System;
using System.Xml.Linq;

namespace LoESoft.Client.Assets.Xml.Structure
{
    public class XmlContent
    {
        public enum ContentType : int
        {
            Players = 0,
            Objects = 1,
            Items = 2,
            Tiles = 3
        }

        public class XmlTexture
        {
            public bool Animated { get; set; }
            public string FileName { get; set; }
            public Tuple<int, int> ImageIndex { get; set; }

            public XmlTexture(XElement elem)
            {
                Animated = bool.Parse(elem.Attribute("animated").Value);
                FileName = elem.Value;
                ImageIndex = new Tuple<int, int>
                (
                    int.Parse(elem.Attribute("x").Value),
                    int.Parse(elem.Attribute("y").Value)
                );
            }
        }

        public XmlContent(XElement elem)
        {
            Type = (ContentType) (int.Parse(elem.Attribute("type").Value));
            Id = int.Parse(elem.Attribute("id").Value);
            Name = elem.Attribute("name").Value;
            Texture = new XmlTexture(elem.Element("Texture"));
        }

        public XmlTexture Texture { get; set; }
        public ContentType Type { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class PlayersContent : XmlContent
    {
        public PlayersContent(XElement elem) : base(elem)
        {
        }
    }

    public class ObjectsContent : XmlContent
    {
        public ObjectsContent(XElement elem) : base(elem)
        {
        }
    }

    public class ItemsContent : XmlContent
    {
        public ItemsContent(XElement elem) : base(elem)
        {
        }
    }

    public class TilesContent : XmlContent
    {
        public TilesContent(XElement elem) : base(elem)
        {
        }
    }
}