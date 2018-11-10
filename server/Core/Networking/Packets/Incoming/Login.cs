using LoESoft.Server.Core.Networking.Packets.Outgoing;
using LoESoft.Server.Core.World.Entities.Player;

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

                if (App.Database.GetCharacterByAccountId(account.Id, 1) == null) // temporarily
                    if (App.Database.CreateNewCharacter(account.Id, 0, $"Player {account.Id}", out string error)) // temporarily
                        client.SendPacket(new ServerResponse()
                        {
                            From = "CreateNewCharacter",
                            Result = 0,
                            Content = "You have successfully created a new character!"
                        }); // temporarily
                    else
                        client.SendPacket(new ServerResponse()
                        {
                            From = "CreateNewCharacter",
                            Result = -1,
                            Content = $"An error occurred while character creation: {error}"
                        }); // temporarily

                client.Account = account; // do not change this
                client.Player = new Player(client.Manager, client, (int)account.Id, account.CurrentCharacterId); // temporarily
            }
        }
    }
}