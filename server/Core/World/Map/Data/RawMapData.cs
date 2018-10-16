using Newtonsoft.Json;

namespace LoESoft.Server.Core.World.Map.Data
{
    public class RawMapData
    {
        public string[,] Tiles;

        public RawMapData() => Tiles = new string[16, 16];

        public void AssignData(TileData[,] data)
        {
            for (var x = 0; x < Chunk.CHUNKSIZE; x++)
                for (var y = 0; y < Chunk.CHUNKSIZE; y++)
                    Tiles[x, y] = JsonConvert.SerializeObject(data[x, y]);
        }
    }
}