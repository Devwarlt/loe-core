using LoESoft.Server.Core.World;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoESoft.Server.Core.Networking.Packets.Outgoing
{
    public class Update : OutgoingPacket
    {
        public string TileData { get; set; }

        [JsonIgnore]
        public override PacketID PacketID => PacketID.UPDATE;
    }
}
