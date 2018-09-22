using Newtonsoft.Json;

namespace LoESoft.Server.Core.Networking.Packets.Outgoing
{
    public class Update : OutgoingPacket
    {
        public string TileData { get; set; }

        [JsonIgnore]
        public override PacketID PacketID => PacketID.UPDATE;
    }
}
