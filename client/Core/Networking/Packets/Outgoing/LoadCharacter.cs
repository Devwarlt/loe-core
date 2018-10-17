using Newtonsoft.Json;

namespace LoESoft.Client.Core.Networking.Packets.Outgoing
{
    public class LoadCharacter : OutgoingPacket
    {
        public int AccountId { get; set; }
        public int Id { get; set; }

        [JsonIgnore]
        public override PacketID PacketID => PacketID.LOAD_CHARACTER;
    }
}