using LoESoft.Server.Core.World.Map;
using LoESoft.Server.Core.World.Map.Data;
using System;

namespace LoESoft.Server.Core.World.Entities
{
    public class Entity : IDisposable
    {
        public static int UNIQUEIDC = 0;
        public WorldManager Manager { get; private set; }

        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;

        public int ChunkX => X / Chunk.SIZE;
        public int ChunkY => Y / Chunk.SIZE;

        public int Id { get; private set; }
        public int UniqueId { get; private set; }

        public Entity(WorldManager manager, int id)
        {
            Manager = manager;
            Id = id;
            UniqueId =  UNIQUEIDC;
            UNIQUEIDC++;
        }

        public virtual void Update()
        {
        }

        public virtual EntityData GetEntityData => new EntityData() { X = X, Y = Y, Id = 0, UniqueId = UniqueId };

        public virtual void Dispose() { }
    }
}