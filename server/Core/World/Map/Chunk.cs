using LoESoft.Server.Core.World.Entities;
using LoESoft.Server.Core.World.Entities.Player;
using LoESoft.Server.Core.World.Map.Data;
using System;
using System.Collections.Generic;

namespace LoESoft.Server.Core.World.Map
{
    public class Chunk
    {
        public static readonly int CHUNKSIZE = 16;

        public TileData[,] Tiles { get; private set; }
        public List<Entity> Entities { get; private set; }
        public List<Player> Players { get; private set; }
        public WorldManager Manager { get; private set; }

        private int _startX;
        private int _startY;

        public bool IsActive => Players.Count > 0;

        public Chunk(WorldManager manager, int chunkx, int chunky)
        {
            Manager = manager;
            Tiles = new TileData[CHUNKSIZE, CHUNKSIZE];
            Entities = new List<Entity>();
            Players = new List<Player>();

            _startX = chunkx * CHUNKSIZE;
            _startY = chunky * CHUNKSIZE;
        }

        public void Update()
        {
            foreach (var i in Entities.ToArray())
                i.Update();

            foreach (var i in Players.ToArray())
                i.Update();
        }

        public void LoadChunk() //temporary
        {
            for (var x = 0; x < CHUNKSIZE; x++)
                for (var y = 0; y < CHUNKSIZE; y++)
                {
                    Tiles[x, y] = new TileData()
                    {
                        X = _startX + x,
                        Y = _startY + y,
                        Id = new Random().Next(0, 4)
                    };

                    Entities.Add(new Entity(Manager)
                    {
                        X = _startX + new Random().Next(0, 16),
                        Y = _startY + new Random().Next(0, 16)
                    });
                }
        }
    }
}