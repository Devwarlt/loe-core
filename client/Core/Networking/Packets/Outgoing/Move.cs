namespace LoESoft.Client.Core.Networking.Packets.Outgoing
{
    public class Move : OutgoingPacket
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override PacketID PacketID => PacketID.MOVE;
    }
}
