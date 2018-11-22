using LoESoft.Server.Core.World.Map.Data;

namespace LoESoft.Server.Core.Networking.Packets.Outgoing
{
    public class Update : OutgoingPacket
    {
        public TileData[] AddOrUpdateTile { get; set; }
        public ObjectData[] AddOrUpdateObject { get; set; }
        //public int[] RemovedObjects { get; set; } ObjectId's of objects that where removed

        public override PacketID PacketID => PacketID.UPDATE;
    }
}