using LoESoft.Server.Core.World.Entities.Player;
using System;
using System.Collections.Generic;

namespace LoESoft.Server.Core.World.Map
{
    public class Chunk
    {
        public static readonly int CHUNKSIZE = 16;

        public TileData[,] Tiles { get; private set; }

        public List<Player> Entities { get; private set; }

        private int _startX;
        private int _startY;

        public Chunk(int chunkx, int chunky)
        {
            Tiles = new TileData[CHUNKSIZE, CHUNKSIZE];
            Entities = new List<Player>();
            _startX = chunkx * CHUNKSIZE;
            _startY = chunky * CHUNKSIZE;
        }

        public void LoadChunk() //temporary
        {
            Random random = new Random();

            for (var x = 0; x < CHUNKSIZE; x++)
                for (var y = 0; y < CHUNKSIZE; y++)
                {
                    int id = random.Next(0, 2);
                    Tiles[x, y] = new TileData() { X = _startX + x, Y = _startY + y, Type = id };
                }
        }
    }
}
