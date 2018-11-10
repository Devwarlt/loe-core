using Newtonsoft.Json;

namespace LoESoft.Client.Core.Networking.Packets.Outgoing
{
    public class Load : OutgoingPacket
    {
        public int AccountId { get; set; }
        public int Id { get; set; }

        [JsonIgnore]
        public override PacketID PacketID => PacketID.LOAD;
    }
}