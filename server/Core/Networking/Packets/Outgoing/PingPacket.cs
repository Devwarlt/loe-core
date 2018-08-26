using LoESoft.Server.Core.Networking.Packets.Outgoing;
using Newtonsoft.Json;

namespace LoESoft.Server.Core.Networking.Packets.Incoming
{
    public class PingPacket : OutgoingPacket
    {
        public int Value { get; set; }

        [JsonIgnore]
        public override PacketID PacketID => PacketID.PING;

        public PingPacket(int value) => Value = value;
    }
}
