using LoESoft.MapEditor.Core.Assets.Structure.Exclusive;
using static LoESoft.MapEditor.Core.Assets.Structure.XmlContent;

namespace LoESoft.MapEditor.Core.Util
{
    public class InteractiveObject
    {
        public ContentType Type { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public LayerData LayerData { get; set; }
        public TextureData TextureData { get; set; }
    }
}