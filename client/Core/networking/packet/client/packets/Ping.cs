namespace LoESoft.Client.Core.networking.packet.client.packets
{
    internal class Ping : ClientPacket
    {
        public int Value { get; set; }

        public override PacketID ID => PacketID.PING;

        public override Packet CreateInstance() => new Ping();
    }
}
