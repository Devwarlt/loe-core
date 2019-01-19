namespace LoESoft.Server.Core.World.Map.Structure
{
    public class Layer
    {
        public MapLayer MapLayer { get; set; }
        public MapSize MapSize { get; set; }
        public ChunkData[,] Chunk { get; set; }

        public Layer(MapLayer layer, MapSize size)
        {
            MapLayer = layer;
            MapSize = size;
            Chunk = new ChunkData[(int)MapSize, (int)MapSize];
        }
    }
}