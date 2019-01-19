using LoESoft.Server.Core.Networking.Packets.Outgoing;

namespace LoESoft.Server.Core.Networking.Packets.Incoming
{
    public class CreateNewCharacter : IncomingPacket
    {
        public int World { get; set; }
        public int ClassType { get; set; }
        public int CharacterIndex { get; set; }

        public override PacketID PacketID => PacketID.CREATE_NEW_CHARACTER;

        public override void Read(NetworkReader reader)
        {
            World = reader.ReadInt32();
            ClassType = reader.ReadInt32();
            CharacterIndex = reader.ReadInt32();
        }

        public override void Handle(NetworkClient client)
        {
            if (client.Account.Id == -1)
            {
                client.SendPacket(new ServerResponse()
                {
                    From = "CreateNewCharacter",
                    Result = -1,
                    Content = "You are not logged in to preform this action!"
                });
                return;
            }

            if (App.Database.CreateNewCharacter(client.Account.Id, World, ClassType, out string error))
            {
                client.SendPacket(new ServerResponse()
                {
                    From = "CreateNewCharacter",
                    Result = 0,
                    Content = $"{CharacterIndex},{ClassType}"
                });
            }
            else
                client.SendPacket(new ServerResponse()
                {
                    From = "CreateNewCharacter",
                    Result = -1,
                    Content = $"An error occurred while character creation: {error}"
                });
        }
    }
}