using LoESoft.Server.Core.Networking.Packets.Outgoing;

namespace LoESoft.Server.Core.Networking.Packets.Incoming
{
    public class CreateNewCharacter : IncomingPacket
    {
        public int AccountId { get; set; }
        public int World { get; set; }
        public string Name { get; set; }

        public override PacketID PacketID => PacketID.CREATE_NEW_CHARACTER;

        public override void Handle(Client client)
        {
            if (client == null)
                return;

            if (AccountId == -1)
            {
                client.SendPacket(new Response()
                {
                    From = "CreateNewCharacter",
                    Result = -1,
                    Content = "You are not logged in to peform this action."
                });
                return;
            }

            if (string.IsNullOrEmpty(Name))
            {
                client.SendPacket(new Response()
                {
                    From = "CreateNewCharacter",
                    Result = -1,
                    Content = "Character name could not be empty."
                });
                return;
            }

            if (Name.Length < 3)
            {
                client.SendPacket(new Response()
                {
                    From = "CreateNewCharacter",
                    Result = -1,
                    Content = "Character name minimum length is 3."
                });
                return;
            }

            if (Name.Length > 20)
            {
                client.SendPacket(new Response()
                {
                    From = "CreateNewCharacter",
                    Result = -1,
                    Content = "Character name maximum length is 20."
                });
                return;
            }

            if (GameServer._database.CreateNewCharacter(AccountId, World, Name))
                client.SendPacket(new Response()
                {
                    From = "CreateNewCharacter",
                    Result = 0,
                    Content = "You have successfully created a new character!"
                });
            else
                client.SendPacket(new Response()
                {
                    From = "CreateNewCharacter",
                    Result = -1,
                    Content = "An error occurred while character creation, try again later..."
                });
        }
    }
}