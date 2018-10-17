using LoESoft.WebServer.Core.Utils;

namespace LoESoft.WebServer.Core.Networking.Packets.Outgoing
{
    public class Login : PacketBase
    {
        public override void Handle()
        {
            string name = Query["name"];
            string password = Query["password"];

            bool isNameNullOrEmpty = string.IsNullOrEmpty(name);
            bool isPasswordNullOrEmpty = string.IsNullOrEmpty(password);

            if (string.IsNullOrWhiteSpace(name))
            {
                OnError("Account name is empty.");
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                OnError("Account password is empty.");
                return;
            }

            var name64 = Cipher.Decrypt(name);
            var pass64 = Cipher.Decrypt(password);

            if (name64.Length < 6)
            {
                OnError("Account name minimum length is 6.");
                return;
            }

            if (pass64.Length < 8)
            {
                OnError("Account password minimum length is 8.");
                return;
            }

            var account = GameWebServer._database.GetAccountByCredentials(name64, pass64);

            if (account == null)
                OnError("Account not found.");
            else
                OnSend(account.Token);
        }
    }
}