using Newtonsoft.Json;

namespace LoESoft.Client.Core.Networking.Packets.Outgoing
{
    public class Ping : OutgoingPacket
    {
        public int Value { get; set; }

        [JsonIgnore]
        public override PacketID PacketID => PacketID.PING;
    }
}