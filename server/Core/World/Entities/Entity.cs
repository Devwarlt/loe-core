using LoESoft.Server.Core.World.Map;
using System;

namespace LoESoft.Server.Core.World.Entities
{
    public class Entity : IDisposable
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int ChunkX { get; set; }
        public int ChunkY { get; set; }

        public Entity(int x, int y)
        {
            X = x;
            Y = y;
        }

        public virtual void Init()
        {
            WorldManager.Map.AddEntity(this);
        }

        public virtual void Move(int x, int y)
        {
            X = x;
            Y = y;

            var cx = X / Chunk.CHUNKSIZE;
            var cy = Y / Chunk.CHUNKSIZE;

            if (ChunkX != cx || ChunkY != cy)
            {
                ChunkX = cx;
                ChunkY = cy;
                RepositionToChunk(cx, cy);
            }
        }

        protected virtual void RepositionToChunk(int cx, int cy)
        {
            WorldManager.Map.RemoveEntity(this, cx, cy);
            WorldManager.Map.AddEntity(this);
        }

        public virtual EntityData GetData()
        {
            return new EntityData() { X = X, Y = Y, Type = 0 };
        }

        public virtual void Dispose() { }
    }
}
