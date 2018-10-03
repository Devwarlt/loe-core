using LoESoft.Server.Core.World.Map;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LoESoft.Server.Core.World
{
    public class RawMapData // temporrary class 
    {
        public string[,] Tiles { get; set; }
        public string[] Entitys { get; set; }
        public string[] Players { get; set; }

        public RawMapData()
        {
            Tiles = new string[Chunk.CHUNKSIZE, Chunk.CHUNKSIZE];
            Entitys = new string[1024];
            Players = new string[120];
        }

        public void AssignEntityData(List<EntityData> entity)
        {
            int idx = 0;
            foreach (var i in entity)
            {
                Entitys[idx] = JsonConvert.SerializeObject(i);
                idx++;
            }
        }

        public void AssignPlayerData(List<PlayerData> player)
        {
            int idx = 0;
            foreach (var i in player)
            {
                Players[idx] = JsonConvert.SerializeObject(i);
                idx++;
            }
        }

        public void AssignTileData(TileData[,] data)
        {
            for (var x = 0; x < Chunk.CHUNKSIZE; x++)
                for (var y = 0; y < Chunk.CHUNKSIZE; y++)
                    Tiles[x, y] = JsonConvert.SerializeObject(data[x, y]);
        }
    }
}
