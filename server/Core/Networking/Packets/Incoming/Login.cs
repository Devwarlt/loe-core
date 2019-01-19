using LoESoft.Server.Core.Networking.Packets.Outgoing;

namespace LoESoft.Server.Core.Networking.Packets.Incoming
{
    public class Login : IncomingPacket
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public override PacketID PacketID => PacketID.LOGIN;

        public override void Read(NetworkReader reader)
        {
            Email = reader.ReadUTF();
            Password = reader.ReadUTF();
        }

        public override void Handle(NetworkClient client)
        {
            if (string.IsNullOrWhiteSpace(Email) && !Email.Contains("@"))
            {
                client.SendPacket(new ServerResponse()
                {
                    From = $"Login",
                    Result = -1,
                    Content = "Please enter a valid Email!"
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

            var account = App.Database.GetAccountByCredentials(Email, Password);

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