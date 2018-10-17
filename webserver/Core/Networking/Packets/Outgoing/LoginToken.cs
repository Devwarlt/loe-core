namespace LoESoft.WebServer.Core.Networking.Packets.Outgoing
{
    public class LoginToken : PacketBase
    {
        public override void Handle()
        {
            string token = Query["token"];

            if (string.IsNullOrWhiteSpace(token))
            {
                OnError("Account token is invalid.");
                return;
            }

            if (token.Length != 128)
            {
                OnError("Account token doesn't match length.");
                return;
            }

            var account = GameWebServer._database.GetAccountByToken(token);

            if (account == null)
                OnError("Account not found.");
            else
                OnSend();
        }
    }
}
