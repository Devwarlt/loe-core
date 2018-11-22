namespace LoESoft.Client.Core.Game.User.Data
{
    public class Inventory
    {
        public Item[] Items { get; set; }

        public Inventory() { }

        public void Init(Item[] items)
        {
            Items = items;
        }
    }
}
