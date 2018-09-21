namespace LoESoft.Client.Core.Networking.Packets.Outgoing
{
    public class Pong : OutgoingPacket
    {
        public int Value { get; set; }

        public override PacketID PacketID => PacketID.PONG;

        public Pong(int value) => Value = value;
    }
}
