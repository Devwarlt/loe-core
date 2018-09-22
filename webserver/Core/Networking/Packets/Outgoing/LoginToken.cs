namespace LoESoft.WebServer.Core.Networking.Packets.Outgoing
{
    public class LoginToken : PacketBase
    {
        /// <summary>
        /// Packet ID:
        /// - (PacketID) LOGIN_TOKEN
        /// Incoming:
        /// - (string) token
        /// Outgoing:
        ///     On error:
        ///     - (string) "Account token is invalid."
        ///     - (string) "Account not found."
        ///     On success:
        ///     - (string) "You are logged in."
        /// </summary>
        public override void Handle()
        {
            string token = Query["token"];

            if (string.IsNullOrEmpty(token) || token.Length != 128)
            {
                OnError("Account token is invalid.");
                return;
            }

            var account = GameWebServer._database.GetAccountByToken(token);

            if (account == null)
            {
                OnError("Account not found.");
                return;
            }

            OnSend("You are logged in.");
        }
    }
}
