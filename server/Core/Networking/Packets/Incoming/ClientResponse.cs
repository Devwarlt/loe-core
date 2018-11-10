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
                case "Client.Character.GetCharacterData":

                    break;
            }
        }

        private void HandleGetCharacterData()
        {

        }
    }
}
