using LoESoft.Server.Core.Networking.Packets.Incoming;

namespace LoESoft.Server.Core.Networking.Packets.Outgoing
{
    public class PongPacket : IncomingPacket
    {
        public int Value { get; set; }

        public override PacketID PacketID => PacketID.PONG;

        public override void Handle(Client client) => GameServer.Info($"Client sent value '{Value}' via Ping packet.");
    }
}