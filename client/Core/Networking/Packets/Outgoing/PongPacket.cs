namespace LoESoft.Client.Core.Networking.Packets.Outgoing
{
    public class PongPacket : OutgoingPacket
    {
        public int Value { get; set; }

        public override PacketID PacketID => PacketID.PONG;

        public PongPacket(int value) => Value = value;
    }
}
