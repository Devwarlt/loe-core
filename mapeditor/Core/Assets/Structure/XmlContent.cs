using LoESoft.MapEditor.Core.Assets.Structure.Exclusive;
using LoESoft.MapEditor.Core.Layer;
using System.Xml.Linq;

namespace LoESoft.MapEditor.Core.Assets.Structure
{
    public partial class XmlContent
    {
        public ContentType Type { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        public LayerData LayerData { get; set; }
        public TextureData TextureData { get; set; }

        private XElement _e { get; set; }

        public XmlContent(XElement elem)
        {
            Type = (ContentType)(int.Parse(elem.Attribute("type").Value));
            Id = int.Parse(elem.Attribute("id").Value);
            Name = elem.Attribute("name").Value;

            if ((_e = elem.Element("Layer")) != null)
                LayerData = new LayerData()
                {
                    Type = (MapLayer)int.Parse(_e.Attribute("type").Value),
                    Group = _e.Attribute("group").Value
                };

            if ((_e = elem.Element("Texture")) != null)
                TextureData = new TextureData()
                {
                    File = _e.Element("FileName").Value,
                    X = int.Parse(_e.Attribute("x").Value),
                    Y = int.Parse(_e.Attribute("y").Value)
                };
        }
    }
}