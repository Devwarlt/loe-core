using LoESoft.Server.Core.Networking.Data;
using LoESoft.Server.Core.World.Entities.Interfaces;
using LoESoft.Server.Core.World.Map;
using LoESoft.Server.Core.World.Stats;
using LoESoft.Server.Utils;

namespace LoESoft.Server.Core.World.Entities
{
    public class GameObject : Comparable, IUpdatable
    {
        protected void IncrementVar<T>(ref T stat, T value)
        {
            stat = value;
            UpdateCount++;
        }

        public WorldManager Manager { get; private set; }
        public StatExportManager Export { get; private set; }
        
        public int Id { get; private set; }
        public int UpdateCount { get; set; }

        public bool IsPlayer { get; set; }
        public bool IsEntity { get; set; }

        //Stats
        public int ChunkX => X / Chunk.SIZE;
        public int ChunkY => Y / Chunk.SIZE;

        private int _realX;
        public int X
        {
            get => _realX;
            set => IncrementVar(ref _realX, value);
        }

        private int _realY;
        public int Y
        {
            get => _realY;
            set => IncrementVar(ref _realY, value);
        }

        private int _size;
        public int Size
        {
            get => _size;
            set => IncrementVar(ref _size, value);
        }

        public GameObject(WorldManager manager, int id)
        {
            Manager = manager;
            Id = id;
            Export = new StatExportManager();
            Size = LoERandom.Next(8, 80);
        }

        public void Move(int x, int y)
        {
            X = x;
            Y = y;
        }

        public virtual Stat[] ExportStat()
        {
            Export.AddOrUpdate(StatType.SIZE, Size);

            return Export.GetStats();
        }

        public virtual void Update()
        {
        }

        public Chunk GetChunk() => Manager.Core.Map.Chunks[new Point(ChunkX, ChunkY)];
            
        public virtual void Dispose() => GetChunk().Remove(this);

        public virtual void OnUpdate() => UpdateCount = 0;
    }
}