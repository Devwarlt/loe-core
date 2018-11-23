using System;
using System.Xml.Linq;

namespace LoESoft.Client.Assets.Xml.Structure
{
    public class XmlContent
    {
        public class XmlTexture
        {
            public bool Animated { get; set; }
            public string FileName { get; set; }
            public Tuple<int, int> ImageIndex { get; set; }

            public XmlTexture(XElement elem)
            {
                Animated = elem.Element("Animated") != null;
                FileName = elem.Element("FileName").Value;
                ImageIndex = new Tuple<int, int>(int.Parse(elem.Attribute("x").Value), int.Parse(elem.Attribute("y").Value));
            }
        }

        public XmlTexture Texture { get; set; }
        public ContentType Type { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        public XmlContent(XElement elem)
        {
            Type = (ContentType)int.Parse(elem.Attribute("type").Value);
            Id = int.Parse(elem.Attribute("id").Value);
            Name = elem.Attribute("name").Value;
            Texture = new XmlTexture(elem.Element("Texture"));
        }
    }
}