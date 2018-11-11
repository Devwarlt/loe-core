using Newtonsoft.Json;

namespace LoESoft.Client.Core.Networking.Packets.Outgoing
{
    public class Load : OutgoingPacket
    {
        public int CharacterIndex { get; set; }

        [JsonIgnore]
        public override PacketID PacketID => PacketID.LOAD;
    }
}