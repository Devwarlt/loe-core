﻿namespace LoESoft.Client.Core.Networking.Packets.Outgoing
{
    public class Load : OutgoingPacket
    {
        public override PacketID PacketID => PacketID.LOAD;
    }
}