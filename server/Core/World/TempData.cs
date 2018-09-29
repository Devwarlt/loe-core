using LoESoft.Server.Core.World.Map;
using Newtonsoft.Json;

namespace LoESoft.Server.Core.World
{
    public class TempData // temporrary class 
    {
        public string[,] Tiles { get; set; }

        public TempData()
        {
            Tiles = new string[Chunk.CHUNKSIZE, Chunk.CHUNKSIZE];
        }

        public void AssignData(TileData[,] data)
        {
            for (var x = 0; x < Chunk.CHUNKSIZE; x++)
                for (var y = 0; y < Chunk.CHUNKSIZE; y++)
                    Tiles[x, y] = JsonConvert.SerializeObject(data[x, y]);
        }
    }
}
