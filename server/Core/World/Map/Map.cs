using LoESoft.Server.Core.World.Entities;
using LoESoft.Server.Core.World.Entities.Player;
using LoESoft.Server.Core.World.Map;
using LoESoft.Server.Core.World.Map.Data;
using Newtonsoft.Json;

namespace LoESoft.Server.Core.World
{
    public class MapData
    {
        public enum DataTypes
        {
            Player = 0,
            Entities = 1,
            Tiles = 2
        }

        public Chunk[,] ChunkMap;

        public MapData()
        {
            ChunkMap = new Chunk[16, 16];

            for (var x = 0; x < Chunk.CHUNKSIZE; x++)
                for (var y = 0; y < Chunk.CHUNKSIZE; y++)
                    ChunkMap[x, y] = new Chunk(x, y);

            foreach (var i in ChunkMap)
                i.LoadChunk();
        }

        #region GETDATA
        public string GetPlayerData(Player player)
        {
            RawPlayerData dat = new RawPlayerData();

            var chunk = ChunkMap[player.ChunkX, player.ChunkY];

            chunk.Players.Remove(player.GetPlayerData());

            dat.AssignData(chunk.Players);

            return JsonConvert.SerializeObject(dat);
        }

        public string GetEntityData(Player player)
        {
            RawEntityData dat = new RawEntityData();

            var chunk = ChunkMap[player.ChunkX, player.ChunkY];

            dat.AssignData(chunk.Entities);

            return JsonConvert.SerializeObject(dat);
        }

        public string GetTileData(Player player)
        {
            RawMapData dat = new RawMapData();

            var chunk = ChunkMap[player.ChunkX, player.ChunkY];

            dat.AssignData(chunk.Tiles);

            return JsonConvert.SerializeObject(dat);
        }
        #endregion

        #region Add/Remove Entites
        public void AddEntity(Entity entity)
        => ChunkMap[entity.ChunkX, entity.ChunkY].Entities.Add(entity.GetData());

        public void AddPlayer(Player player) =>
            ChunkMap[player.ChunkX, player.ChunkY].Players.Add(player.GetPlayerData());

        public void RemoveEntity(Entity entity)
        => ChunkMap[entity.ChunkX, entity.ChunkY].Entities.Remove(entity.GetData());

        public void RemovePlayer(Player player)
        => ChunkMap[player.ChunkX, player.ChunkY].Players.Remove(player.GetPlayerData());
        #endregion
    }
}