using LoESoft.Server.Core.Networking.Data;

namespace LoESoft.Server.Core.Networking.Packets.Outgoing
{
    public class GamePlayerUpdate : OutgoingPacket
    {
        public override PacketID PacketID => PacketID.PLAYER_UPDATE;

        public int ObjectId { get; set; }
        public int Id { get; set; }
        public Stat[] Stats { get; set; }

        public override void Write(NetworkWriter writer)
        {
            writer.Write(ObjectId);
            writer.Write(Id);

            writer.Write(Stats.Length);
            foreach (var i in Stats)
                i.Write(writer);
        }
    }
}
