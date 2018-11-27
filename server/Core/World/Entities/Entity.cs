using LoESoft.Server.Assets.Xml;
using LoESoft.Server.Assets.Xml.Structure;
using LoESoft.Server.Core.World.Entities.Interfaces;
using LoESoft.Server.Core.World.Map;
using LoESoft.Server.Core.World.Stats;
using LoESoft.Server.Utils;
using System;

namespace LoESoft.Server.Core.World.Entities
{
    public class Entity : Comparable, IUpdatable
    {
        public WorldManager Manager { get; private set; }
        public StatExportManager Export { get; private set; }

        protected void IncrementVar<T>(ref T stat, T value)
        {
            stat = value;
            UpdateCount++;
        }

        public int Id { get; private set; }

        public int UpdateCount { get; set; }

        //Stats
        public int ChunkX => X / Chunk.SIZE;

        public int ChunkY => Y / Chunk.SIZE;

        private int _realX;

        public int X
        {
            get => _realX;
            set => IncrementVar<int>(ref _realX, value);
        }

        private int _realY;

        public int Y
        {
            get => _realY;
            set => IncrementVar<int>(ref _realY, value);
        }

        private int _size;

        public int Size
        {
            get => _size;
            set => IncrementVar<int>(ref _size, value);
        }

        public Entity(WorldManager manager, int id)
        {
            Manager = manager;
            ObjectId = EntityManager.GetNextId();
            Id = id;
            Export = new StatExportManager();
            Size = 8;
        }

        public void Move(int x, int y)
        {
            X = x;
            Y = y;
        }

        public virtual string ExportStat()
        {
            Export.AddOrUpdate(StatType.SIZE, Size);

            return Export.Serialize();
        }

        public virtual void Update()
        {
        }

        public Chunk GetChunk() => Manager.Core.Map.Chunks[new Point(ChunkX, ChunkY)];
            
        public virtual void Dispose() =>
            Manager.Core.Map.Chunks[new Point(ChunkX, ChunkY)].Remove(this);

        public virtual void OnUpdate() => UpdateCount = 0;
    }
}