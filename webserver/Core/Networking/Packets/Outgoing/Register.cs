using LoESoft.WebServer.Core.Utils;

namespace LoESoft.WebServer.Core.Networking.Packets.Outgoing
{
    public class Register : PacketBase
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

            var isAccountNameExist = GameWebServer._database.CheckAccountNameIfExists(name64);

            if (isAccountNameExist)
            {
                OnError("Account name already registered.");
                return;
            }

            GameWebServer._database.CreateNewAccount(name64, pass64, out string token);

            OnSend(token);
        }
    }
}
