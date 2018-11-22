using LoESoft.Server.Assets.Xml;

namespace LoESoft.Server.Core.World.Entities.Player.Attribute
{
    public class Inventory
    {
        public Item[] Items { get; set; }

        public Inventory()
        {
            Items = new Item[32];

            for (var i = 0; i < Items.Length; i++)
                SetItem(i, Item.Create(XmlLibrary.ItemsXml[9]));
        }

        public void SetItem(int idx, Item item) => Items[idx] = item;

        public void RemoveItem(int idx, out Item item)
        {
            item = Items[idx];
            Items[idx] = null;
        }
    }
}