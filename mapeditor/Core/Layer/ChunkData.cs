using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using static LoESoft.MapEditor.Core.Assets.Structure.XmlContent;

namespace LoESoft.MapEditor.Core.Layer
{
    public class ChunkData
    {
        public ContentType ContentType { get; set; }
        public int Id { get; set; }
        public string Group { get; set; }
        public int BoundX { get; set; }
        public int BoundY { get; set; }

        [JsonIgnore]
        public int GridX { get; set; }
        [JsonIgnore]
        public int GridY { get; set; }
        [JsonIgnore]
        public Vector2 Vector { get; set; }
    }
}