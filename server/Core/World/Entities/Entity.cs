using LoESoft.Server.Core.World.Entities.Interfaces;
using LoESoft.Server.Core.World.Map;
using LoESoft.Server.Core.World.Stats;
using System;

namespace LoESoft.Server.Core.World.Entities
{
    public class Entity : IUpdatable
    {
        public WorldManager Manager { get; private set; }
        public StatExportManager Export { get; private set; }

        private void IncrementVar<T>(ref T stat, T value)
        {
            stat = value;
            UpdateCount++;
        }

        public int Id { get; private set; }
        public int ObjectId { get; private set; }

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

        private int _hp;

        public int Health
        {
            get => _hp;
            set => IncrementVar<int>(ref _hp, value);
        }

        public Entity(WorldManager manager, int id)
        {
            Manager = manager;
            ObjectId = EntityManager.GetNextId();
            Id = id;
            Export = new StatExportManager();
            Health = new Random().Next(10, 100);
        }

        public void Move(int x, int y)
        {
            X = x;
            Y = y;
        }

        public virtual string ExportStat()
        {
            Export.AddOrUpdate(StatType.HEALTH, Health);

            return Export.Serialize();
        }

        public virtual void Update()
        {
        }

        public virtual void Dispose()
        {
            Manager.Core.Map.Chunks[new Tuple<int, int>(ChunkX, ChunkY)].Remove(this);
        }

        public static Entity Create(WorldManager manager, int x, int y, int id)
        {
            var entity = new Entity(manager, id)
            {
                X = x,
                Y = y
            };

            return entity;
        }

        public void OnUpdate()
        {
            UpdateCount = 0;
        }
    }
}