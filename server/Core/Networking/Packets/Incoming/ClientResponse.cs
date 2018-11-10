using LoESoft.Server.Core.Networking.Packets.Outgoing;

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
            switch(From)
            {
                case "Client.Character.GetUnlockedCharacters":
                    HandleUnlockedCharacters(client);
                    break;
            }
        }

        private void HandleUnlockedCharacters(Client client)
        {
            App.Warn("Sending Character Unlocked Info!");

            client.SendPacket(new ServerResponse()
            {
                From = "Server.Character.UnlockedCharacters",
                Result = 0, //Assumes that player even has a character
                Content = "5,5,5" //Id's of classes
            });
        }
    }
}
