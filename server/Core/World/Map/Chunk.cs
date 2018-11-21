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

        public void Add(Entity entity) => Entities.Add(entity);

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

        private Random rand = new Random();

        public void RandomGen()
        {
            for (var i = 0; i < 2; i++)
                Add(new Entity(Manager, 8)
                {
                    X = rand.Next(StartX, StartX + 5),
                    Y = rand.Next(StartY, StartY + 5)
                });
        }

        #endregion METHODS

        public void Update()
        {
            foreach (var i in Entities)
                i.Move(rand.Next(1, 3), rand.Next(1, 3));
        }
    }
}