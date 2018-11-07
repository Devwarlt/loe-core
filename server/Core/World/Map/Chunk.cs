using LoESoft.Server.Core.World.Entities;
using LoESoft.Server.Core.World.Entities.Player;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoESoft.Server.Core.World.Map
{
    public class Chunk
    {
        public static int SIZE = 256; 

        public readonly int StartX;
        public readonly int StartY;

        public WorldManager Manager { get; private set; }

        public List<Entity> Entities { get; private set; }

        public Chunk(WorldManager manager, int x, int y)
        {
            Manager = manager;

            Entities = new List<Entity>();

            StartX = x * SIZE;
            StartX = y * SIZE;
        }

        #region METHODS
        public void Add(Entity entity)
        {
            entity.ObjectId = Entity.GetNextObjectId();
            Entities.Add(entity);
        }
        public void Remove(Entity entity) => Entities.Remove(entity);
        public void Contains(Entity entity) => Entities.Contains(entity);

        public List<Entity> GetEntities(IEnumerable<Points> radius) => 
            radius.Select(_ => Entities.Where(e => e.X == _.X && e.Y == _.Y).First()).ToList();

        public Entity GetEntity(int x, int y)
        {
            foreach (var i in Entities)
                if (i.X == x && i.Y == y)
                    return i;
            return null;
        }

        public void RandomGen()
        {
            var rand = new Random();

            for (var i = 0; i < 100; i++)
                Entities.Add(new Entity(Manager, 6)
                {
                    X = rand.Next(StartX, StartX + SIZE),
                    Y = rand.Next(StartY, StartY + SIZE)
                });
        }
        #endregion METHODS

        public void Update()
        {
        }
    }
}