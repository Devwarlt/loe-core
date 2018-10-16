using LoESoft.Server.Core.Networking.Packets.Outgoing;
using Newtonsoft.Json;

namespace LoESoft.Server.Core.Networking.Packets.Incoming
{
    public class Ping : OutgoingPacket
    {
        public int Value { get; set; }

        [JsonIgnore]
        public override PacketID PacketID => PacketID.PING;
    }
}