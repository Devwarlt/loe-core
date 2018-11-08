using System;
using System.Xml.Linq;

namespace LoESoft.Client.Assets.Xml.Structure
{
    public partial class XmlContent
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
    }
}