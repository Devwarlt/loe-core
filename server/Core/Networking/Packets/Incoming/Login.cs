using LoESoft.Server.Core.Networking.Packets.Outgoing;
using System.Linq;

namespace LoESoft.Server.Core.Networking.Packets.Incoming
{
    public class Login : IncomingPacket
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public override PacketID PacketID => PacketID.LOGIN;

        public override void Handle(Client client)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                client.SendPacket(new ServerResponse()
                {
                    From = $"Login",
                    Result = -1,
                    Content = "Account name is empty."
                });
                return;
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                client.SendPacket(new ServerResponse()
                {
                    From = $"Login",
                    Result = -1,
                    Content = "Account password is empty."
                });
                return;
            }

            if (Name.Length < 6)
            {
                client.SendPacket(new ServerResponse()
                {
                    From = $"Login",
                    Result = -1,
                    Content = "Account name minimum length is 6."
                });
                return;
            }

            if (Password.Length < 8)
            {
                client.SendPacket(new ServerResponse()
                {
                    From = $"Login",
                    Result = -1,
                    Content = "Account password minimum length is 8."
                });
                return;
            }

            var account = App.Database.GetAccountByCredentials(Name, Password);

            if (account == null)
            {
                client.SendPacket(new ServerResponse()
                {
                    From = $"Login",
                    Result = -1,
                    Content = "Account not found."
                });
                return;
            }
            else
            {
                client.SendPacket(new ServerResponse()
                {
                    From = $"Login",
                    Result = 0,
                    Content = "You have successfully logged in, enjoy the game!"
                });

                client.Account = account; 
            }
        }
    }
}