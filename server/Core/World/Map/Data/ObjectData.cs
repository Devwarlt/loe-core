using LoESoft.Server.Core.World.Entities;

namespace LoESoft.Server.Core.World.Map.Data
{
    public class ObjectData
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Id { get; set; }

        public static ObjectData GetData(Entity entity) => new ObjectData()
        {
            X = entity.X,
            Y = entity.Y,
            Id = entity.Id
        };
    }
}
