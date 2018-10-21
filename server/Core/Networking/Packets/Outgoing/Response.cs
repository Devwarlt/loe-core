using Newtonsoft.Json;

namespace LoESoft.Server.Core.Networking.Packets.Outgoing
{
    public class Response : OutgoingPacket
    {
        public string From { get; set; }
        public int Result { get; set; }
        public string Content { get; set; }

        [JsonIgnore]
        public override PacketID PacketID => PacketID.RESPONSE;
    }
}