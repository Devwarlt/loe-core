using LoESoft.Server.Core.World.Entities;
using LoESoft.Server.Core.World.Entities.Player;
using LoESoft.Server.Core.World.Map;
using LoESoft.Server.Core.World.Map.Data;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace LoESoft.Server.Core.World
{
    public class MapData
    {
        public Chunk[,] ChunkMap;

        public WorldManager Manager { get; private set; }

        public MapData(WorldManager manager)
        {
            ChunkMap = new Chunk[16, 16];

            Manager = manager;

            for (var x = 0; x < Chunk.CHUNKSIZE; x++)
                for (var y = 0; y < Chunk.CHUNKSIZE; y++)
                    ChunkMap[x, y] = new Chunk(Manager, x, y);

            foreach (var i in ChunkMap)
                i.LoadChunk();
        }

        public void Update()
        {
            foreach (var i in ChunkMap)
                if (i.IsActive)
                    i.Update();
        }

        #region "Manage chunks"

        public void RepositionPlayer(Player player, int x, int y)
        {
            try
            {
                var idx = ChunkMap[player.ChunkX, player.ChunkY].Players.IndexOf(player);

                ChunkMap[player.ChunkX, player.ChunkY].Players[idx].X = x;
                ChunkMap[player.ChunkX, player.ChunkY].Players[idx].Y = y;
            }
            catch (ArgumentOutOfRangeException) { }
        }

        #endregion

        #region "Get data"

        public string GetPlayerData(Player player)
        {
            var dat = new RawPlayerData();
            dat.AssignData(ChunkMap[player.ChunkX, player.ChunkY].Players.Where(_ => _ != player).ToList());

            return JsonConvert.SerializeObject(dat);
        }

        public string GetEntityData(Player player)
        {
            var dat = new RawEntityData();
            dat.AssignData(ChunkMap[player.ChunkX, player.ChunkY].Entities);

            return JsonConvert.SerializeObject(dat);
        }

        public string GetTileData(Player player)
        {
            var dat = new RawMapData();
            dat.AssignData(ChunkMap[player.ChunkX, player.ChunkY].Tiles);

            return JsonConvert.SerializeObject(dat);
        }

        #endregion

        #region "Add/Remove entites"

        public void AddEntity(Entity entity)
            => ChunkMap[entity.ChunkX, entity.ChunkY].Entities.Add(entity);

        public void AddPlayer(Player player)
            => ChunkMap[player.ChunkX, player.ChunkY].Players.Add(player);

        public void RemoveEntity(Entity entity)
            => ChunkMap[entity.ChunkX, entity.ChunkY].Entities.Remove(entity);

        public void RemovePlayer(Player player)
            => ChunkMap[player.ChunkX, player.ChunkY].Players.Remove(player);

        #endregion
    }
}