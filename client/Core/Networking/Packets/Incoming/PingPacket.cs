using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.Networking.Packets.Outgoing;

namespace LoESoft.Client.Core.Networking.Packets.Incoming
{
    public class PingPacket : IncomingPacket
    {
        public int Value { get; set; }

        public override PacketID PacketID => PacketID.PING;

        public override void Handle(GameUser gameUser)
        {
            //gameUser.SendPacket(new PongPacket(Value));
            GameClient.Info(Value.ToString());
        }
    }
}
