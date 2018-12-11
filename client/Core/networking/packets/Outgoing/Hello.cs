namespace LoESoft.Client.Core.Networking.Packets.Outgoing
{
    public class Hello : OutgoingPacket
    {
        public int CharacterIndex { get; set; }

        public override PacketID PacketID => PacketID.HELLO;
    }
}
