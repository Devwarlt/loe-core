using LoESoft.Server.Assets.Xml;
using LoESoft.Server.Assets.Xml.Structure;
using System;

namespace LoESoft.Server.Core.World.Entities.Player.Attribute
{
    public class Inventory
    {
        public Item[] Items { get; set; }
        Random _rand = new Random();
        public Inventory()
        {
            Items = new Item[32];

            for (var i = 0; i < Items.Length; i++)
                SetItem(i, Item.Create(XmlLibrary.ItemsXml[_rand.Next(9, 12)] as ItemsContent));
        }

        public void SetItem(int idx, Item item) => Items[idx] = item;

        public void RemoveItem(int idx, out Item item)
        {
            item = Items[idx];
            Items[idx] = null;
        }
    }
}