namespace LoESoft.Server.Core.Networking.Packets.Outgoing
{
    public class ServerResponse : OutgoingPacket
    {
        public string From { get; set; }
        public int Result { get; set; }
        public string Content { get; set; }
        
        public override PacketID PacketID => PacketID.SERVER_RESPONSE;

        public override void Write(NetworkWriter writer)
        {
            writer.WriteUTF(From);
            writer.Write(Result);
            writer.WriteUTF(Content);
        }
    }
}