namespace LoESoft.Server.Core.Networking.Packets.Outgoing
{
    public class GamePlayerUpdate : OutgoingPacket
    {
        public override PacketID PacketID => PacketID.PLAYER_UPDATE;

        public string Stats { get; set; }

        public int ObjectId { get; set; }
        public int Id { get; set; }
    }
}
