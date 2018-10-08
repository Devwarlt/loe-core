using LoESoft.Server.Core.World.Map;
using LoESoft.Server.Core.World.Map.Data;
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

        public virtual void Move(int x, int y)
        {
            X = x;
            Y = y;

            var cx = x / Chunk.CHUNKSIZE;
            var cy = y / Chunk.CHUNKSIZE;

            if (cx > ChunkX || cy > ChunkY)
            {
                RepositionToChunk();
            }
            
            ChunkX = cx;
            ChunkY = cy;
        }

        protected virtual void RepositionToChunk()
        {
            WorldManager.Map.RemoveEntity(this);
            WorldManager.Map.AddEntity(this);
        }

        public virtual EntityData GetData()
        {
            return new EntityData() { X = X, Y = Y, Type = 0 };
        }

        public virtual void Dispose() { }
    }
}
