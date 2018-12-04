using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.Game.Map;
using LoESoft.Client.Core.Game.Map.Data;

namespace LoESoft.Client.Core.Networking.Packets.Incoming
{
    public class Update : IncomingPacket
    {
        public TileData[] AddOrUpdateTile { get; set; }
        public ObjectData[] AddOrUpdateObject { get; set; }
        public int[] RemovedObjects { get; set; }

        public override PacketID PacketID => PacketID.UPDATE;

        public override void Handle(GameUser user) => 
            WorldMap.AddOrUpdate(AddOrUpdateTile, AddOrUpdateObject, RemovedObjects);
    }
}