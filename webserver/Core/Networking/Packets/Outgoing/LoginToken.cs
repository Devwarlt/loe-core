namespace LoESoft.WebServer.Core.Networking.Packets.Outgoing
{
    public class LoginToken : PacketBase
    {
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
                OnError("Account credentials are not valid. Try again later.");
                return;
            }
        }
    }
}
