namespace LoESoft.WebServer.Core.Networking.Packets.Outgoing
{
    public class Ping : PacketBase
    {
        /// <summary>
        /// Packet ID:
        /// - (PacketID) PING
        /// Incoming:
        /// - (int) value
        /// Outgoing:
        ///     On error:
        ///     - (string) "Value is invalid."
        ///     On success:
        ///     - (string) "Client sent '<c>value</c>' value via Ping packet."
        /// </summary>
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
