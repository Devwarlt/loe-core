using LoESoft.Server.Core.Networking.Packets.Outgoing;
using LoESoft.Server.Core.World.Map;
using LoESoft.Server.Core.World.Map.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoESoft.Server.Core.World.Entities.Player
{
    public partial class Player
    {
        public override void Update()
        {
            var tileData = new RawMapData();
            var entityData = new RawEntityData();
            var playerData = new RawPlayerData();
            
            foreach (var i in GetSightPoints())
            {
                var x = X + i.X;
                var y = Y + i.Y;

                tileData.SetData<TileData>(GetTile(x, y));

                foreach (var p in GetPlayer(x, y))
                    playerData.SetData<PlayerData>(p);
            }

            Client.SendPacket(new Update()
            {
                WorldData = JsonConvert.SerializeObject(tileData),
                EntityData = JsonConvert.SerializeObject(entityData),
                PlayerData = JsonConvert.SerializeObject(playerData)
            });
        }

        private TileData GetTile(int x , int y)
        {
            try { return Manager.Map.Tiles[x, y].GetData; } catch { return null; }
        }

        private PlayerData[] GetPlayer(int x, int y) //Could be more than 1 player standing on same Tile
        {
            var data = new List<PlayerData>();
            try
            {
                foreach (var i in Manager.Map.Players.Where(_ => _.X == x && _.Y == y))
                    data.Add(i.GetPlayerData);

                return data.ToArray();
            } catch { return null; }
        }
    }
}
