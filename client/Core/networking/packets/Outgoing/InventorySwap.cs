﻿namespace LoESoft.Client.Core.Networking.Packets.Outgoing
{
    public class InventorySwap : OutgoingPacket
    {
        public int ParentItemIndex { get; set; }
        public int TargetItemIndex { get; set; }

        public override PacketID PacketID => PacketID.INVENTORY_SWAP;

        public override void Write(NetworkWriter writer)
        {
            writer.Write(ParentItemIndex);
            writer.Write(TargetItemIndex);
        }
    }
}
