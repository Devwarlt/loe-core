using Newtonsoft.Json;

namespace LoESoft.Client.Core.Networking.Packets.Outgoing
{
    public class CreateNewCharacter : OutgoingPacket
    {
        public int AccountId { get; set; }
        public int World { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public override PacketID PacketID => PacketID.CREATE_NEW_CHARACTER;
    }
}
