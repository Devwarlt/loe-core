﻿using LoESoft.Server.Core.World.Entities;
using LoESoft.Server.Utils;
using System.Collections.Generic;
using System.Linq;

namespace LoESoft.Server.Core.World.Map
{
    public class Chunk
    {
        public const int SIZE = 128;

        public readonly int StartX;
        public readonly int StartY;

        public WorldManager Manager { get; private set; }

        public HashSet<GameObject> Entities { get; private set; }
        public HashSet<int> RemovedEntities { get; private set; }

        public Chunk(WorldManager manager, int x, int y)
        {
            Manager = manager;

            Entities = new HashSet<GameObject>();
            RemovedEntities = new HashSet<int>();

            StartX = x * SIZE;
            StartX = y * SIZE;
        }

        #region METHODS
        public void Add(GameObject entity) => Entities.Add(entity);

        public void Remove(GameObject entity)
        {
            RemovedEntities.Add(entity.ObjectId);
            Entities.Remove(entity);
        }

        public void Contains(GameObject entity) => Entities.Contains(entity);

        public HashSet<GameObject> GetEntities(IEnumerable<Point> radius) =>
            radius.Select(_ => Entities.Where(e => e.X == _.X && e.Y == _.Y).First()).ToHashSet();

        public GameObject GetEntity(int x, int y) => Entities.Where(_ => _.X == x && _.Y == y).FirstOrDefault();
        
        public void RandomGen()
        {
            for (var i = 0; i < 3; i++)
                Add(EntityManager.CreateEntity(Manager, StartX + LoERandom.Next(0, 20), 
                    StartY + LoERandom.Next(0, 20), 8));
        }
        #endregion METHODS

        public void Update(WorldTime time)
        {
            if (time.TickCount % 5 == 0)
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