using Newtonsoft.Json;

namespace LoESoft.Server.Core.Networking.Packets.Outgoing
{
    public class CharacterData : OutgoingPacket
    {
        public string Character { get; set; }

        [JsonIgnore]
        public override PacketID PacketID => PacketID.CHARACTER_DATA;
    }
}
