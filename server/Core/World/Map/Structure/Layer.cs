using LoESoft.Server.Assets.Xml;
using Newtonsoft.Json;

namespace LoESoft.Server.Core.World.Map.Structure
{
    public class Layer
    {
        public MapLayer MapLayer { get; set; }
        public MapSize MapSize { get; set; }
        public ChunkData[,] Chunk { get; set; } // used to read-only

        [JsonIgnore] public ChunkObject[,] Chunks { get; set; }

        public Layer(MapLayer layer, MapSize size)
        {
            MapLayer = layer;
            MapSize = size;
            Chunk = new ChunkData[(int)MapSize, (int)MapSize];
            Chunks = new ChunkObject[(int)MapSize, (int)MapSize];
        }

        public void UpdateChunksToObject()
        {
            for (var x = 0; x < (int)MapSize; x++)
                for (var y = 0; y < (int)MapSize; y++)
                    Chunks[x, y] = new ChunkObject()
                    {
                        ContentType = Chunk[x, y].ContentType,
                        XmlContent = XmlLibrary.GetXmlsByContentType(Chunk[x, y].ContentType)[Chunk[x, y].Id]
                    };
        }
    }
}