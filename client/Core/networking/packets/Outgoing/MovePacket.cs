using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoESoft.Client.Core.Networking.Packets.Outgoing
{
    public class MovePacket : OutgoingPacket
    {
        public int Value { get; set; }

        public override PacketID PacketID => PacketID.MOVE;

        public MovePacket(int x) => Value = x;
    }
}
