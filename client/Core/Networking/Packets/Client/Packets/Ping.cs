namespace LoESoft.Client.Core.Networking.Packets.Client.Packets
{
    internal class Ping : ClientPacket
    {
        public int Value { get; set; }

        public override PacketID ID => PacketID.PING;

        public override Packet CreateInstance() => new Ping();
    }
}
