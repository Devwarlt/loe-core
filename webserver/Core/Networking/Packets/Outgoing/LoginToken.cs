using LoESoft.WebServer.Core.Utils;

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

            var token64 = Cipher.Decrypt(token);

            if (token64.Length != 128)
            {
                OnError("Account token doesn't match length.");
                return;
            }

            var account = GameWebServer._database.GetAccountByToken(token64);

            if (account == null)
                OnError("Account not found.");
            else
                OnSend();
        }
    }
}
