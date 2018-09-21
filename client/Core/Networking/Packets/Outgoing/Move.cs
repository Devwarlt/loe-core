namespace LoESoft.Client.Core.Networking.Packets.Outgoing
{
    public class Move : OutgoingPacket
    {
        public int Value { get; set; }

        public override PacketID PacketID => PacketID.MOVE;
    }
}
