namespace LoESoft.WebServer.Core.Networking.Packets.Outgoing
{
    public class Ping : PacketBase
    {
        public override void Handle() => GameWebServer.Info($"Client sent '{Query["value"]}' value via Ping packet.");
    }
}
