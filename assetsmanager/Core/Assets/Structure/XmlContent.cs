using System.Xml.Linq;

namespace LoESoft.AssetsManager.Core.Assets.Structure
{
    public partial class XmlContent
    {
        public ContentType Type { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        private XElement _e { get; set; }

        public XmlContent(XElement elem)
        {
            Type = (ContentType)int.Parse(elem.Attribute("type").Value);
            Id = int.Parse(elem.Attribute("id").Value);
            Name = elem.Attribute("name").Value;
        }
    }
}