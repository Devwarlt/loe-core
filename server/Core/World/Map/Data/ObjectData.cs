using LoESoft.Server.Core.World.Entities;
using LoESoft.Server.Core.World.Entities.Player;

namespace LoESoft.Server.Core.World.Map.Data
{
    public class ObjectData
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Id { get; set; }
        public bool IsPlayer { get; set; }
        public int ObjectId { get; set; }

        public static ObjectData GetData(Entity entity) => new ObjectData()
        {
            X = entity.X,
            Y = entity.Y,
            Id = entity.Id,
            IsPlayer = (entity is Player),
            ObjectId = entity.ObjectId
        };
    }
}
