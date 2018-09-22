namespace LoESoft.WebServer.Core.Networking.Packets.Outgoing
{
    public class Ping : PacketBase
    {
        public override void Handle()
        {
            string value = Query["value"];

            if (string.IsNullOrEmpty(value))
            {
                OnError("Value is invalid.");
                return;
            }

            string message = $"Client sent '{Query["value"]}' value via Ping packet.";

            GameWebServer.Info(message);

            OnSend(message);
        }
    }
}
