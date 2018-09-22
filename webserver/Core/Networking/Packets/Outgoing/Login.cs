using System.Xml.Linq;

namespace LoESoft.WebServer.Core.Networking.Packets.Outgoing
{
    public class Login : PacketBase
    {
        public override void Handle()
        {
            string name = Query["name"];
            string password = Query["password"];

            if (string.IsNullOrEmpty(name) || name.Length < 6)
            {
                OnError(new XElement("Account name is invalid."));
                return;
            }

            if (string.IsNullOrEmpty(password) || password.Length < 8)
            {
                OnError("Account password is invalid.");
                return;
            }

            var account = GameWebServer._database.GetAccountByCredentials(name, password);

            if (account == null)
            {
                OnError("Account credentials are not valid. Try again later.");
                return;
            }

            OnSend(SerializeToXml(account), true);
        }
    }
}
