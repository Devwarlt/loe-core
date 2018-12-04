using LoESoft.Server.Assets.Xml;
using LoESoft.Server.Assets.Xml.Structure;

namespace LoESoft.Server.Core.World.Entities
{
    public class ItemData
    {
        public int MaximumDamage { get; set; }
        public int MinimumDamage { get; set; }
        public int AttackFrequency { get; set; }
        public int Armor { get; set; }

        public string Name { get; set; }

        public static ItemData Default(ItemsContent content) => new ItemData()
        {
            MaximumDamage = 1,
            MinimumDamage = 0,
            AttackFrequency = 1,
            Name = content.Name
        };
    }

    public class Item
    {
        public int Id { get; set; }
        public ItemData Data { get; set; }

        public Item(int id)
        {
            Id = id;
            Data = ItemData.Default((ItemsContent)XmlLibrary.ItemsXml[Id]);
        }

        public static Item Create(ItemsContent content) => new Item(content.Id)
        {
            Data = ItemData.Default(content)
        };
    }
}