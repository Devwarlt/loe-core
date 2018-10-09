using Newtonsoft.Json;

namespace LoESoft.Server.Core.Networking.Packets.Outgoing
{
    public class Update : OutgoingPacket
    {
        public string WorldData { get; set; }

        public string EntityData { get; set; }

        public string PlayerData { get; set; }
        
        public override PacketID PacketID => PacketID.UPDATE;
    }
}
