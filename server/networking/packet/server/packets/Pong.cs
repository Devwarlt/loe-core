namespace LoESoft.Server.networking.packet.server.packets
{
    public class Pong : ServerPacket
    {
        public int Value { get; set; }

        public override PacketID ID => PacketID.PONG;

        public override Packet CreateInstance() => new Pong();
    }
}
