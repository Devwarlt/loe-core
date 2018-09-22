namespace LoESoft.WebServer.Core.Networking.Packets.Outgoing
{
    public class Login : PacketBase
    {
        public override void Handle()
        {
            string name = Query["name"];
            string password = Query["password"];

            bool isNameInvalid = string.IsNullOrEmpty(name) || name?.Length < 6;
            bool isPasswordInvalid = string.IsNullOrEmpty(password) || password?.Length < 8;

            if (isNameInvalid || isPasswordInvalid)
            {
                if (isNameInvalid)
                    OnError("Account name is invalid.");
                else
                    OnError("Account password is invalid.");

                return;
            }

            var account = GameWebServer._database.GetAccountByCredentials(name, password);

            if (account == null)
            {
                OnError("Account not found.");
                return;
            }

            OnSend("You are logged in.");
        }
    }
}
