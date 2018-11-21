using LoESoft.Server.Assets.Xml.Structure;

namespace LoESoft.Server.Core.World.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static Item Create(ItemsContent content)
        {
            return new Item()
            {
                Id = content.Id,
                Name = content.Name
            };
        }
    }
}