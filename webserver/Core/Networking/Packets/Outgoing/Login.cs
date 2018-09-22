namespace LoESoft.WebServer.Core.Networking.Packets.Outgoing
{
    public class Login : PacketBase
    {
        /// <summary>
        /// Packet ID:
        /// - (PacketID) LOGIN
        /// Incoming:
        /// - (string) name
        /// - (string) password
        /// Outgoing:
        ///     On error:
        ///     - (string) "Account name is invalid."
        ///     - (string) "Account password is invalid."
        ///     - (string) "Account not found."
        ///     On success:
        ///     - (string) "You are logged in."
        /// </summary>
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
