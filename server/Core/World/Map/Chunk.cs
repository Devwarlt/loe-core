using LoESoft.Server.Core.World.Entities;
using LoESoft.Server.Core.World.Entities.Player;
using LoESoft.Server.Core.World.Map.Data;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace LoESoft.Server.Core.World.Map
{
    public class Chunk
    {
        public static int SIZE = 16; //Chunks are 16 by 16

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

        public bool CanContain(int x, int y) => ((x >= StartX && x <= StartY + SIZE) && (y >= StartY && y <= StartY + SIZE));
        #endregion METHODS

        public void Update()
        {
            foreach(var i in Entities.ToArray())
            {
                if (CanContain(i.X, i.Y))
                    i.Update();
                else
                {
                    Entities.Remove(i);
                    Manager.Map.Add(i);
                }
            }
        }
    }
}