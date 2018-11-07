namespace LoESoft.Client.Core.Networking.Packets.Outgoing
{
    public class ClientMove : OutgoingPacket
    {
        public int Direction { get; set; }

        public override PacketID PacketID => PacketID.CLIENTMOVE;
    }
}