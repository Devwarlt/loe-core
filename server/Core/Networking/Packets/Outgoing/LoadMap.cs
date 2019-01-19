namespace LoESoft.Server.Core.Networking.Packets.Outgoing
{
    public class LoadMap : OutgoingPacket
    {
        public int MapWidth { get; set; }
        public int MapHeight { get; set; }

        public override PacketID PacketID => PacketID.LOAD_MAP;

        public override void Write(NetworkWriter writer)
        {
            writer.Write(MapWidth);
            writer.Write(MapHeight);
        }
    }
}