using LoESoft.Client.Core.Game.Objects;
using Newtonsoft.Json;

namespace LoESoft.Client.Core.Networking.Packets.Outgoing
{
    public class ClientMove : OutgoingPacket //UDP Packets are not being recieved
    {
        public int Direction { get; set; }

        public override PacketID PacketID => PacketID.CLIENTMOVE;

        [JsonIgnore]
        public Player Player { get; set; }
    }
}