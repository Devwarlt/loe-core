using LoESoft.Server.Core.World.Entities;

namespace LoESoft.Server.Core.Networking.Data
{
    public class ObjectData
    {
        public int ObjectId { get; set; }
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Stat[] Stats { get; set; }

        public int LastDirection { get; set; }
        public bool IsPlayer { get; set; }
        public bool IsEntity { get; set; }

        public void Write(NetworkWriter writer)
        {
            writer.Write(ObjectId);
            writer.Write(Id);
            writer.Write(X);
            writer.Write(Y);

            writer.Write(Stats.Length);
            foreach (var i in Stats)
                i.Write(writer);

            writer.Write(LastDirection);
            writer.WriteBool(IsPlayer);
            writer.WriteBool(IsEntity);
        }

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