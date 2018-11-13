using LoESoft.Server.Core.Networking.Packets.Outgoing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LoESoft.Server.Core.Networking.Packets.Incoming
{
    public class ClientResponse : IncomingPacket
    {
        public string From { get; set; }
        public int Result { get; set; }
        public string Content { get; set; }

        public override PacketID PacketID => PacketID.CLIENT_REPONSE;

        public override void Handle(Client client)
        {
            switch (From)
            {
                case "Client.Character.GetUnlockedCharacters":
                    HandleUnlockedCharacters(client);
                    break;
            }
        }

        private class UnlockedCharacterData
        {
            public int[] UnlockedClassTypes { get; set; }

            public UnlockedCharacterData(int[] arr) => UnlockedClassTypes = arr;
        }

        private void HandleUnlockedCharacters(Client client)
        {
            try
            {
                var characters = App.Database.GetCharactersByAccountId(client.Account.Id, out string error);

                var content = new List<int>();

                App.Warn(characters.Count.ToString() + $": {error}");

                for (var i = 0; i < 3; i++)
                    if (i < client.Account.CurrentCharacterId)
                        content.Add(characters[i].Class);
                    else
                        content.Add(-1);

                App.Warn(content.Count.ToString());

                client.SendPacket(new ServerResponse()
                {
                    From = "Server.Character.UnlockedCharacters",
                    Result = 0,
                    Content = JsonConvert.SerializeObject(new UnlockedCharacterData(content.ToArray())) //Id's of classes
                });
            }
            catch (Exception ex)
            {
                App.Warn(ex.ToString());
            }
        }
    }
}