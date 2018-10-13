using LoESoft.Client.Core.Game.Objects;
using Newtonsoft.Json;

namespace LoESoft.Client.Core.Networking.Packets.Outgoing
{
    public class ClientMove : OutgoingPacket, IUdpPacket
    {
        public int Direction { get; set; } 
    
        public override PacketID PacketID => PacketID.CLIENTMOVE;
        
        [JsonIgnore]
        public Player Player { get; set; }
    }
}
