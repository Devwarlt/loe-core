using LoESoft.Server.Core.Networking.Packets.Outgoing;
using LoESoft.Server.Core.World;
using LoESoft.Server.Core.World.Entities.Player;

namespace LoESoft.Server.Core.Networking.Packets.Incoming
{
    public class Load : IncomingPacket
    {
        public int CharacterIndex { get; set; }

        public override PacketID PacketID => PacketID.LOAD;

        public override void Handle(Client client)
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
            App.Warn("TEST!2");

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
                client.SendPacket(new LoadMap()
                {
                    MapWidth = WorldMap.WIDTH,
                    MapHeight = WorldMap.HEIGHT
                });
                //client.SendPacket(new ServerResponse()
                //{
                //});

                client.Player = new Player(client.Manager, client, (int)client.Account.Id, getCharacterData.Class);

                client.Player.Move(getCharacterData.Position.X, getCharacterData.Position.Y);

                client.Manager.TryAddPlayer(client);
            }
        }
    }
}