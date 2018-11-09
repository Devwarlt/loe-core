using LoESoft.Server.Core.Networking.Packets.Outgoing;
using Newtonsoft.Json;

namespace LoESoft.Server.Core.Networking.Packets.Incoming
{
    public class LoadCharacter : IncomingPacket
    {
        public int AccountId { get; set; }
        public int Id { get; set; }

        public override PacketID PacketID => PacketID.LOAD_CHARACTER;

        public override void Handle(Client client)
        {
            if (AccountId == -1)
            {
                client.SendPacket(new Response()
                {
                    From = "LoadCharacter",
                    Result = -1,
                    Content = "You are not logged in to peform this action."
                });
                return;
            }

            var getCharacterData = App.Database.GetCharacterByAccountId(AccountId, Id);

            if (getCharacterData == null)
                client.SendPacket(new Response()
                {
                    From = "LoadCharacter",
                    Result = -1,
                    Content = "Character not found, try again later..."
                });
            else
                client.SendPacket(new CharacterData()
                {
                    Character = JsonConvert.SerializeObject(getCharacterData)
                });
        }
    }
}