using LoESoft.Server.Core.World.Entities;
using LoESoft.Server.Utils;
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

        public HashSet<Entity> Entities { get; private set; }
        public HashSet<int> RemovedEntities { get; private set; }

        public Chunk(WorldManager manager, int x, int y)
        {
            Manager = manager;

            Entities = new HashSet<Entity>();
            RemovedEntities = new HashSet<int>();

            StartX = x * SIZE;
            StartX = y * SIZE;
        }

        #region METHODS

        public void Add(Entity entity) => Entities.Add(entity);

        public void Remove(Entity entity)
        {
            RemovedEntities.Add(entity.ObjectId);
            Entities.Remove(entity);
        }

        public void Contains(Entity entity) => Entities.Contains(entity);

        public List<Entity> GetEntities(IEnumerable<Point> radius) =>
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
            for (var i = 0; i < 5; i++)
                Add(EntityManager.CreateEntityObject(Manager, StartX + rand.Next(0, 20), StartY + rand.Next(0, 20), 8));
        }

        #endregion METHODS

        public void Update(WorldTime time)
        {
            if (time.TickCount % 10 == 0)
            {
                foreach (var i in Entities.ToArray())
                {
                    if (Manager.Core.Map.Players.FirstOrDefault().Value != null)
                    {
                        var player = Manager.Core.Map.Players.FirstOrDefault();
                        i.Move(player.Value.X, player.Value.Y);
                    }
                }
            }
        }
    }
}