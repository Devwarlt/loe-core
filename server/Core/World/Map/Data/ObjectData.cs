using LoESoft.Server.Core.World.Entities;
using LoESoft.Server.Core.World.Entities.Player;

namespace LoESoft.Server.Core.World.Map.Data
{
    public class ObjectData
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Id { get; set; }
        public int ObjectId { get; set; }
        public int LastDirection { get; set; }

        public string Stats { get; set; }

        public bool IsPlayer { get; set; }

        public static ObjectData GetData(Entity entity) => new ObjectData()
        {
            Id = entity.Id,
            ObjectId = entity.ObjectId,
            X = entity.X,
            Y = entity.Y,
            LastDirection = (entity is Player) ? ((Player)entity).CurrentDirection : -1,
            Stats = entity.ExportStat(),
            IsPlayer = entity is Player
        };
    }
}