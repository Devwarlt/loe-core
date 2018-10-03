using LoESoft.Server.Core.World.Entities;
using LoESoft.Server.Core.World.Entities.Player;
using LoESoft.Server.Core.World.Map;
using Newtonsoft.Json;

namespace LoESoft.Server.Core.World
{
    public class MapData
    {
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
        
        public string GetData(Player player)
        {
            RawMapData dat = new RawMapData();

            var chunk = ChunkMap[player.ChunkX, player.ChunkY];

            //chunk.Players.Remove(player.GetData() as PlayerData);//to not send players self

            dat.AssignTileData(chunk.Tiles);
            dat.AssignEntityData(chunk.Entities);
            dat.AssignPlayerData(chunk.Players);

            return JsonConvert.SerializeObject(dat);
        }

        #region Add/Remove Entites
        public void AddEntity(Entity entity)
        => ChunkMap[entity.ChunkX, entity.ChunkY].Entities.Add(entity.GetData());

        public void AddPlayer(Player player) =>
            ChunkMap[player.ChunkX, player.ChunkY].Players.Add(player.GetData() as PlayerData);

        public void RemoveEntity(Entity entity, int cx, int cy)
        => ChunkMap[cx, cy].Entities.Remove(entity.GetData());

        public void RemovePlayer(Player player, int cx, int cy)
        => ChunkMap[cx, cy].Players.Remove(player.GetData() as PlayerData);
        #endregion
    }
}