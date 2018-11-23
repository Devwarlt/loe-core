using static LoESoft.Server.Assets.Xml.Structure.XmlContent;

namespace LoESoft.Server.Core.World.Map.Structure
{
    public class ChunkData
    {
        public ContentType ContentType { get; set; }
        public int Id { get; set; }
        public string Group { get; set; }
        public int BoundX { get; set; }
        public int BoundY { get; set; }
    }
}