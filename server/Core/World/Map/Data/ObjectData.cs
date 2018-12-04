using LoESoft.Server.Core.World.Entities;

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
        public bool IsEntity { get; set; }

        public static ObjectData GetData(GameObject entity) => new ObjectData()
            {
                Id = entity.Id,
                ObjectId = entity.ObjectId,
                X = entity.X,
                Y = entity.Y,
                IsPlayer = entity.IsPlayer,
                IsEntity = entity.IsEntity,
                Stats = entity.ExportStat(),
                LastDirection = (entity.IsPlayer || entity.IsEntity) ? (int)(entity as Entity).Direction : -1
            };
    }
}