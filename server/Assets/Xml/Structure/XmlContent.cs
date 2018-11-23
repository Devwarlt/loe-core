using System.Xml.Linq;

namespace LoESoft.Server.Assets.Xml.Structure
{
    public partial class XmlContent : IXmlContent
    {
        public ContentType Type { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        public XmlContent(XElement elem)
        {
            Type = (ContentType)(int.Parse(elem.Attribute("type").Value));
            Id = int.Parse(elem.Attribute("id").Value);
            Name = elem.Attribute("name").Value;
        }
    }
}