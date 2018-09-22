namespace LoESoft.WebServer.Core.Networking.Packets.Outgoing
{
    public class Register : PacketBase
    {
        /// <summary>
        /// Packet ID:
        /// - (PacketID) REGISTER
        /// Incoming:
        /// - (string) name
        /// - (string) password
        /// Outgoing:
        ///     On error:
        ///     - (string) "Account name is empty."
        ///     - (string) "Account name minimum length is 6."
        ///     - (string) "Account password is empty."
        ///     - (string) "Account password minimum length is 8."
        ///     - (string) "Account name already registered."
        ///     On success:
        ///     - (string) "Your token is: <c>token</c>"
        /// </summary>
        public override void Handle()
        {
            string name = Query["name"];
            string password = Query["password"];

            bool isNameNullOrEmpty = string.IsNullOrEmpty(name);
            bool isNameValidLength = name?.Length >= 6;
            bool isPasswordNullOrEmpty = string.IsNullOrEmpty(password);
            bool isPasswordValidLength = password?.Length >= 8;
            bool isNameInvalid = isNameNullOrEmpty || !isNameValidLength;
            bool isPasswordInvalid = isPasswordNullOrEmpty || !isPasswordValidLength;

            if (isNameInvalid || isPasswordInvalid)
            {
                if (isNameInvalid)
                {
                    if (isNameNullOrEmpty)
                        OnError("Account name is empty.");
                    else
                        OnError("Account name minimum length is 6.");
                }
                else
                {
                    if (isPasswordNullOrEmpty)
                        OnError("Account password is empty.");
                    else
                        OnError("Account password minimum length is 8.");
                }

                return;
            }

            var isAccountNameExist = GameWebServer._database.CheckAccountNameIfExists(name);

            if (isAccountNameExist)
            {
                OnError("Account name already registered.");
                return;
            }

            GameWebServer._database.CreateNewAccount(name, password, out string token);

            OnSend($"Your token is: {token}");
        }
    }
}
