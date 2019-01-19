using LoESoft.Server.Core.Networking.Data;
using LoESoft.Server.Core.Networking.Packets.Outgoing;
using LoESoft.Server.Core.World.Entities.Player;
using Newtonsoft.Json;

namespace LoESoft.Server.Core.Networking.Packets.Incoming
{
    public class Hello : IncomingPacket
    {
        public int CharacterIndex { get; set; }

        public override PacketID PacketID => PacketID.HELLO;

        public override void Read(NetworkReader reader)
        {
            CharacterIndex = reader.ReadInt32();
        }

        public override void Handle(NetworkClient client)
        {
            if (client.Account.Id == -1)
            {
                client.SendPacket(new ServerResponse()
                {
                    From = "LoadCharacter",
                    Result = -1,
                    Content = "You are not logged in to peform this action."
                });
                return;
            }

            var getCharacterData = App.Database.GetCharacterByAccountId(client.Account.Id, CharacterIndex);

            if (getCharacterData == null)
                client.SendPacket(new ServerResponse()
                {
                    From = "LoadCharacter",
                    Result = -1,
                    Content = "Character not found, try again later..."
                });
            else
            {
                client.Player = new Player(client.Manager, client, getCharacterData);

                if (client.Manager.TryAddPlayer(client, out var error))
                {
                    string info = JsonConvert.SerializeObject(new PlayerInfo()
                    {
                        ClassId = getCharacterData.Class,
                        ObjectId = client.Player.ObjectId
                    });

                    client.SendPacket(new ServerResponse()
                    {
                        From = "LoadCharacter",
                        Result = 0,
                        Content = info
                    });
                } else
                {
                    client.SendPacket(new ServerResponse()
                    {
                        From = "LoadCharacter",
                        Result = -1,
                        Content = error
                    });
                }
            }
        }
    }
}
