using LoESoft.Client.Core.Game.Objects.Stats;
using LoESoft.Client.Core.Networking;

namespace LoESoft.Client.Core.Game.Map.Data
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

        public void Read(NetworkReader reader)
        {
            ObjectId = reader.ReadInt32();
            Id = reader.ReadInt32();
            X = reader.ReadInt32();
            Y = reader.ReadInt32();

            var length = reader.ReadInt32();
            Stats = new Stat[length];
            for(var i = 0; i < length; i++)
            {
                Stats[i] = new Stat();
                Stats[i].Read(reader);
            }

            LastDirection = reader.ReadInt32();
            IsPlayer = reader.ReadBool();
            IsEntity = reader.ReadBool();
        }
    }
}