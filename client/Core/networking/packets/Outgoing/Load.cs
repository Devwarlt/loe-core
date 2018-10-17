using Newtonsoft.Json;

namespace LoESoft.Client.Core.Networking.Packets.Outgoing
{
    public class Load : OutgoingPacket
    {
        [JsonIgnore]
        public override PacketID PacketID => PacketID.LOAD;
    }
}