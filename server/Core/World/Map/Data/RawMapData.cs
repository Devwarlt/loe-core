using LoESoft.Server.Core.World.Entities;
using LoESoft.Server.Core.World.Entities.Player;
using LoESoft.Server.Core.World.Map.Data;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LoESoft.Server.Core.World.Map.Data
{
    public class RawMapData
    {
        public string[,] Tiles;

        public RawMapData()
        {
            Tiles = new string[16, 16];
        }

        public void AssignData(TileData[,] data)
        {
            for (var x = 0; x < Chunk.CHUNKSIZE; x++)
                for (var y = 0; y < Chunk.CHUNKSIZE; y++)
                    Tiles[x, y] = JsonConvert.SerializeObject(data[x, y]);
        }
    }
    public class RawEntityData
    {
        public string[] Entity;

        public RawEntityData()
        {
            Entity = new string[] { };
        }

        public void AssignData(List<Entity> data)
        {
            var dataToFormat = data.ConvertAll<EntityData>(_ => _.GetData());
            Entity = dataToFormat.ConvertAll<string>(_ => JsonConvert.SerializeObject(_)).ToArray();
        }
    }
    public class RawPlayerData
    {
        public string[] Player;

        public RawPlayerData()
        {
            Player = new string[] { };
        }

        public void AssignData(List<Player> data)
        {
            var dataToFormat = data.ConvertAll<PlayerData>(_ => _.GetPlayerData());

            Player = dataToFormat.ConvertAll<string>(_ => JsonConvert.SerializeObject(_)).ToArray();
        }
    }
}
