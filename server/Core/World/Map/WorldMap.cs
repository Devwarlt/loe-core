using LoESoft.Server.Core.Networking.Packets.Outgoing;
using LoESoft.Server.Core.World.Entities;
using LoESoft.Server.Core.World.Entities.Player;
using LoESoft.Server.Core.World.Map;
using System;
using System.Collections.Generic;

namespace LoESoft.Server.Core.World
{
    public class WorldMap
    {
        public static int WIDTH = 256;
        public static int HEIGHT = 256;

        public WorldManager Manager { get; set; }

        public Tile[,] Tiles { get; private set; }
        public Dictionary<Tuple<int, int>, Chunk> Chunks { get; private set; }

        private bool Loaded = false;

        public WorldMap(WorldManager manager)
        {
            Manager = manager;

            Tiles = new Tile[256, 256];
            Chunks = new Dictionary<Tuple<int, int>, Chunk>();
            Players = new List<Player>();

            //Temporary Initiazation
            var rand = new Random();

            for (var x = 0; x < WIDTH; x++)
                for (var y = 0; y < HEIGHT; y++)
                    Tiles[x, y] = new Tile(Manager, rand.Next(0, 4)) { X = x, Y = y };

            Chunks.Add(new Tuple<int, int>(0, 0), new Chunk(Manager, 0, 0));
            Chunks[new Tuple<int, int>(0, 0)].RandomGen();

            Loaded = true;
        }

        public List<Player> Players { get; set; }

        public void Update()
        {
            if (Loaded)
            {
                foreach (var i in Chunks.Values)
                    i.Update();

                foreach (var i in Players.ToArray())
                    i.Update();
            }
        }

        public bool IsValidPosition(int x, int y) => (x >= 0 && x < WIDTH && y >= 0 && y < HEIGHT);

        public void Add(Player player)
        {
            player.Client.SendPacket(new LoadMap()
            {
                MapWidth = WIDTH,
                MapHeight = HEIGHT
            });

            Players.Add(player);
        }

        public void Add(Entity entity) => Chunks[new Tuple<int, int>(entity.ChunkX, entity.ChunkY)].Add(entity);

        public void Remove(Player player) => Players.Remove(player);

        public void Dispose()
        {
            Players.Clear();
            Chunks.Clear();
            Tiles = null;
        }
    }
}