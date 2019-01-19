namespace LoESoft.Server.Core.Networking.Packets.Incoming
{
    public class InventorySwap : IncomingPacket
    {
        public override PacketID PacketID => PacketID.INVENTORY_SWAP;

        public int ParentItemIndex { get; set; }
        public int TargetItemIndex { get; set; }

        public override void Read(NetworkReader reader)
        {
            ParentItemIndex = reader.ReadInt32();
            TargetItemIndex = reader.ReadInt32();
        }

        public override void Handle(NetworkClient client)
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
