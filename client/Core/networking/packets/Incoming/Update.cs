using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.Game.Map;
using LoESoft.Client.Core.Game.Map.Data;
using System.Linq;

namespace LoESoft.Client.Core.Networking.Packets.Incoming
{
    public class Update : IncomingPacket
    {
        public TileData[] AddOrUpdateTile { get; set; }
        public ObjectData[] AddOrUpdateObject { get; set; }

        public override PacketID PacketID => PacketID.UPDATE;

        public override void Handle(GameUser user)
        {
            var player = GameApplication.GameScreen.Controller;
            var objects = AddOrUpdateObject.ToList();

            if (AddOrUpdateObject.ToList().Exists(_ => _.ObjectId == player.ObjectId))
            {
                var gameplayer = objects.Where(_ => _.ObjectId == player.ObjectId).FirstOrDefault();

                if (gameplayer != null)
                    GameApplication.GameScreen.Controller.ImportStat(gameplayer.Stats);
                
                objects.RemoveAll(_ => _.ObjectId == player.ObjectId);
            }

            WorldMap.AddOrUpdate(AddOrUpdateTile, objects.ToArray());
        }
    }
}