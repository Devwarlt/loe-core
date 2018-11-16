using Newtonsoft.Json;

namespace LoESoft.Client.Core.Networking.Packets.Outgoing
{
    public class Register : OutgoingPacket
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        [JsonIgnore]
        public override PacketID PacketID => PacketID.REGISTER;
    }
}