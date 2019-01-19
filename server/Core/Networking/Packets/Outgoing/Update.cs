using LoESoft.Server.Core.Networking.Data;

namespace LoESoft.Server.Core.Networking.Packets.Outgoing
{
    public class Update : OutgoingPacket
    {
        public TileData[] AddOrUpdateTile { get; set; }
        public ObjectData[] AddOrUpdateObject { get; set; }
        public int[] RemovedObjects { get; set; }

        public override PacketID PacketID => PacketID.UPDATE;

        public override void Write(NetworkWriter writer)
        {
            writer.Write(AddOrUpdateTile.Length);
            for (var i = 0; i < AddOrUpdateTile.Length; i++)
                AddOrUpdateTile[i].Write(writer);

            writer.Write(AddOrUpdateObject.Length);
            for (var i = 0; i < AddOrUpdateObject.Length; i++)
                AddOrUpdateObject[i].Write(writer);

            writer.Write(RemovedObjects.Length);
            for (var i = 0; i < RemovedObjects.Length; i++)
                writer.Write(RemovedObjects[i]);
        }
    }
}