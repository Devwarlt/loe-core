using Newtonsoft.Json;

namespace LoESoft.Client.Core.Game.User.Data
{
    public class ItemData
    {
        public int MaximumDamage { get; set; }
        public int MinimumDamage { get; set; }
        public int AttackFrequency { get; set; }

        public string Name { get; set; }
    }

    public class Item
    {
        public int Id { get; set; }
        public ItemData Data { get; set; }

        public static Item Deserailize(string val) => JsonConvert.DeserializeObject<Item>(val);
    }
}