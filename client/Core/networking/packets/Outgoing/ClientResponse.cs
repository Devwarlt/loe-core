using Newtonsoft.Json;

namespace LoESoft.Client.Core.Networking.Packets.Outgoing
{
    public class ClientResponse : OutgoingPacket
    {
        public string From { get; set; }
        public int Result { get; set; }
        public string Content { get; set; }

        [JsonIgnore]
        public override PacketID PacketID => PacketID.CLIENT_REPONSE;
    }
}