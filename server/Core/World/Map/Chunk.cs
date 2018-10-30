using LoESoft.Server.Core.World.Entities;
using LoESoft.Server.Core.World.Entities.Player;
using LoESoft.Server.Core.World.Map.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoESoft.Server.Core.World.Map
{
    public class Chunk
    {
        public static readonly int CHUNKSIZE = 16;

        public TileData[,] Tiles { get; private set; }
        public List<Entity> Entities { get; private set; }
        public List<Player> Players { get; private set; }

        public WorldManager Manager { get; private set; }

        private readonly int StartX;
        private readonly int StartY;

        public bool IsActive => Players.Count > 0;

        public Chunk(WorldManager manager, int chunkx, int chunky)
        {
            Manager = manager;
            Tiles = new TileData[CHUNKSIZE, CHUNKSIZE];
            Entities = new List<Entity>();
            Players = new List<Player>();

            StartX = chunkx * CHUNKSIZE;
            StartY = chunky * CHUNKSIZE;
        }

        public void Update()
        {
            Entities.ToArray().Select(entity => { entity.Update(); return entity; }).ToList();
            Players.ToArray().Select(player => { player.Update(); return player; }).ToList();
        }

        public void LoadChunk() //temporary
        {
            var random = new Random();

            for (var x = 0; x < CHUNKSIZE; x++)
                for (var y = 0; y < CHUNKSIZE; y++)
                {
                    Tiles[x, y] = new TileData()
                    {
                        X = StartX + x,
                        Y = StartY + y,
                        Id = random.Next(0, 4)
                    };

                    Entities.Add(new Entity(Manager)
                    {
                        X = StartX + random.Next(0, 16),
                        Y = StartY + random.Next(0, 16)
                    });
                }
        }
    }
}