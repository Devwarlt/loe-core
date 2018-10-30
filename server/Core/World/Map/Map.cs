using LoESoft.Server.Core.World.Entities;
using LoESoft.Server.Core.World.Entities.Player;
using LoESoft.Server.Core.World.Map;
using LoESoft.Server.Core.World.Map.Data;
using Newtonsoft.Json;
using System.Collections.Generic;
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

            ChunkMap.Select(chunk => { chunk.LoadChunk(); return chunk; }).ToList();
        }

        public void Update()
            => ChunkMap.Where(chunk => chunk.IsActive).Select(chunk => { chunk.Update(); return chunk; }).ToList();
        
        public bool IsValidChunk(int x, int y)
            => ((x >= 0 && x < 16 * 16) && (y >= 0 && y < 16 * 16));
        
        #region "Get data"

        public string GetPlayerData(Player player)
        {
            var dat = new RawPlayerData();
            
            ChunkMap[player.ChunkX, player.ChunkY].Players.Where(_ => !_.Equals(player)).Select(player => {
                dat.SetData<PlayerData>(player.GetPlayerData);
                return player;
            }).ToList();

            return JsonConvert.SerializeObject(dat);
        }

        public string GetEntityData(Player player)
        {
            var dat = new RawEntityData();

            ChunkMap[player.ChunkX, player.ChunkY].Entities.Select(entity => {
                dat.SetData<EntityData>(entity.GetData);
                return entity;
            }).ToList();

            return JsonConvert.SerializeObject(dat);
        }

        public string GetTileData(Player player)
        {
            var dat = new RawMapData();

            ChunkMap[player.ChunkX, player.ChunkY].Tiles.Select(tile => {
                dat.SetData<TileData>(tile);
                return tile;
            }).ToList();
            
            return JsonConvert.SerializeObject(dat);
        }

        #endregion "Get data"

        #region "Add/Remove entites"

        public void AddEntity(Entity entity)
            => ChunkMap[entity.ChunkX, entity.ChunkY].Entities.Add(entity);

        public void AddPlayer(Player player)
            => ChunkMap[player.ChunkX, player.ChunkY].Players.Add(player);

        public void RemoveEntity(Entity entity)
            => ChunkMap[entity.ChunkX, entity.ChunkY].Entities.Remove(entity);

        public void RemovePlayer(Player player)
            => ChunkMap[player.ChunkX, player.ChunkY].Players.Remove(player);

        #endregion "Add/Remove entites"
    }
}
