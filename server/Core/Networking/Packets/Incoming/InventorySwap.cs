namespace LoESoft.Server.Core.Networking.Packets.Incoming
{
    public class InventorySwap : IncomingPacket
    {
        public override PacketID PacketID => PacketID.INVENTORY_SWAP;

        public int ParentItemIndex { get; set; }
        public int TargetItemIndex { get; set; }

        public override void Handle(Client client)
        {
            var target = client.Player.Inventory[TargetItemIndex];
            var parent = client.Player.Inventory[ParentItemIndex];

            client.Player.Inventory[ParentItemIndex] = target;
            client.Player.Inventory[TargetItemIndex] = parent;

            client.Player.UpdateCount++;

            App.Warn($"Inventory Swapped! P:{ParentItemIndex} T:{TargetItemIndex}");
        }
    }
}
