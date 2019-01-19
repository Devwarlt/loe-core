namespace LoESoft.Client.Core.Networking.Packets.Outgoing
{
    public class ClientResponse : OutgoingPacket
    {
        public string From { get; set; }
        public int Result { get; set; }
        public string Content { get; set; }
        
        public override PacketID PacketID => PacketID.CLIENT_REPONSE;

        public override void Write(NetworkWriter writer)
        {
            writer.WriteUTF(From);
            writer.Write(Result);
            writer.WriteUTF(Content);
        }
    }
}