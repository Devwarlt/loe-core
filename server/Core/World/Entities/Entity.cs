using LoESoft.Server.Core.World.Map;
using LoESoft.Server.Core.World.Map.Data;
using System;

namespace LoESoft.Server.Core.World.Entities
{
    public class Entity : IDisposable
    {
        public WorldManager Manager { get; private set; }

        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        public int ChunkX { get; set; } = 0;
        public int ChunkY { get; set; } = 0;

        public Entity(WorldManager manager) => Manager = manager;

        public virtual void Update()
        {
            var cx = X / Chunk.CHUNKSIZE;
            var cy = Y / Chunk.CHUNKSIZE;

            if (cx != ChunkX || cy != ChunkY)
                RepositionToChunk(cx, cy);
        }

        protected virtual void RepositionToChunk(int cx, int cy)
        {
            Manager.Map.RemoveEntity(this);

            ChunkX = cx;
            ChunkY = cy;

            Manager.Map.AddEntity(this);
        }

        public virtual EntityData GetData => new EntityData() { X = X, Y = Y, Id = 0 };

        public virtual void Dispose() => Manager.Map.RemoveEntity(this);
    }
}