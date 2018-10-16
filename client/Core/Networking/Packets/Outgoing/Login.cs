using Newtonsoft.Json;

namespace LoESoft.Client.Core.Networking.Packets.Outgoing
{
    public class Login : OutgoingPacket
    {
        public string Name { get; set; }
        public string Password { get; set; }

        [JsonIgnore]
        public override PacketID PacketID => PacketID.LOGIN;
    }
}
