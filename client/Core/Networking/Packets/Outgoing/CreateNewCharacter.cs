using Newtonsoft.Json;

namespace LoESoft.Client.Core.Networking.Packets.Outgoing
{
    public class CreateNewCharacter : OutgoingPacket
    {
        public int World { get; set; }
        public int ClassType { get; set; }
        public int CharacterIndex { get; set; }

        [JsonIgnore]
        public override PacketID PacketID => PacketID.CREATE_NEW_CHARACTER;
    }
}