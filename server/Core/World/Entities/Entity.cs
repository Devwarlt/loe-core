using LoESoft.Server.Core.World.Map;

namespace LoESoft.Server.Core.World.Entities
{
    public class Entity
    {
        public WorldManager Manager { get; private set; }

        public int ChunkX => X / Chunk.SIZE;
        public int ChunkY => Y / Chunk.SIZE;

        private int _realX;

        public int X
        {
            get => _realX;
            set
            {
                _realX = value;
                UpdateCount++;
            }
        }

        private int _realY;

        public int Y
        {
            get => _realY;
            set
            {
                _realY = value;
                UpdateCount++;
            }
        }

        public int Id { get; private set; }
        public int ObjectId { get; set; }

        public int UpdateCount { get; set; }

        public Entity(WorldManager manager, int id)
        {
            Manager = manager;
            Id = id;
        }

        public void Move(int x, int y)
        {
            if (x >= 0 && X < WorldMap.WIDTH && Y >= 0 && Y < WorldMap.HEIGHT)
            {
                X = x;
                Y = y;
            }
        }

        public virtual void Update()
        {
        }

        public virtual void Dispose()
        {
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
    }
}