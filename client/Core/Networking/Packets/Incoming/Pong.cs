using LoESoft.Client.Core.Client;

namespace LoESoft.Client.Core.Networking.Packets.Incoming
{
    public class Pong : IncomingPacket
    {
        public int Value { get; set; }

        public override PacketID PacketID => PacketID.PONG;

        public override void Handle(GameUser gameUser) => BrmeClient.Info($"Server sent value '{Value}' via Ping packet.");
    }
}