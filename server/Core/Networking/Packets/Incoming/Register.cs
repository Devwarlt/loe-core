using LoESoft.Server.Core.Networking.Packets.Outgoing;
using LoESoft.Server.Core.Utils;

namespace LoESoft.Server.Core.Networking.Packets.Incoming
{
    public class Register : IncomingPacket
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public override PacketID PacketID => PacketID.REGISTER;

        public override void Handle(Client client)
        {
            if (client == null)
                return;

            if (string.IsNullOrWhiteSpace(Name))
            {
                client.SendPacket(new Response()
                {
                    From = "Regiser",
                    Result = -1,
                    Content = "Account name is empty."
                });
                return;
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                client.SendPacket(new Response()
                {
                    From = "Regiser",
                    Result = -1,
                    Content = "Account password is empty."
                });
                return;
            }

            var name64 = Cipher.Decrypt(Name);
            var pass64 = Cipher.Decrypt(Password);

            if (name64.Length < 6)
            {
                client.SendPacket(new Response()
                {
                    From = "Regiser",
                    Result = -1,
                    Content = "Account name minimum length is 6."
                });
                return;
            }

            if (pass64.Length < 8)
            {
                client.SendPacket(new Response()
                {
                    From = "Regiser",
                    Result = -1,
                    Content = "Account password minimum length is 8."
                });
                return;
            }

            var isAccountNameExist = App.Database.CheckAccountNameIfExists(name64);

            if (isAccountNameExist)
            {
                client.SendPacket(new Response()
                {
                    From = "Regiser",
                    Result = -1,
                    Content = "Account name already registered."
                });
                return;
            }

            if (App.Database.CreateNewAccount(name64, pass64, out string token))
                client.SendPacket(new Response()
                {
                    From = "Regiser",
                    Result = 0,
                    Content = "You have successfully registered a brand-new account, enjoy the game!"
                });
            else
                client.SendPacket(new Response()
                {
                    From = "Regiser",
                    Result = -1,
                    Content = "An error occurred while account registration, try again later..."
                });
        }
    }
}