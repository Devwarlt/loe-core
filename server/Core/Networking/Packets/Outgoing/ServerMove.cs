namespace LoESoft.Server.Core.Networking.Packets.Outgoing
{
    public class ServerMove : OutgoingPacket
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override PacketID PacketID => PacketID.SERVERMOVE;
    }
}