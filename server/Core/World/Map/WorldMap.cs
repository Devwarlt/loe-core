using LoESoft.Server.Core.World.Entities;
using LoESoft.Server.Core.World.Entities.Player;
using LoESoft.Server.Core.World.Map;
using LoESoft.Server.Utils;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace LoESoft.Server.Core.World
{
    public class WorldMap
    {
        public static int WIDTH = 256;
        public static int HEIGHT = 256;

        public WorldManager Manager { get; set; }

        public Tile[,] Tiles { get; private set; }
        public Dictionary<Point, Chunk> Chunks { get; private set; }
        public ConcurrentDictionary<int, Player> Players { get; private set; }

        private bool Loaded { get; set; }

        public WorldMap(WorldManager manager)
        {
            Loaded = false;
            Manager = manager;

            Chunks = new Dictionary<Point, Chunk>();
            Players = new ConcurrentDictionary<int, Player>();

            Tiles = new Tile[WIDTH, HEIGHT];

            var rand = new Random();

            for (var x = 0; x < WIDTH; x++)
                for (var y = 0; y < HEIGHT; y++)
                    Tiles[x, y] = new Tile(Manager, rand.Next(0, 4)) { X = x, Y = y };

            var entrypoint = new Point(0, 0);

            Chunks.Add(entrypoint, new Chunk(Manager, 0, 0));

            Chunks[entrypoint].RandomGen();

            Loaded = true;

            App.Warn("Map Successfully Initialized!");
        }

        public void Update(WorldTime time)
        {
            if (Loaded)
            {
                foreach (var i in Chunks.Values)
                    i.Update(time);

                foreach (var i in Players.ToArray())
                    i.Value.Update();
            }
        }

        public bool IsValidPosition(int x, int y) => x >= 0 && x < WIDTH && y >= 0 && y < HEIGHT;

        public void Add(Player player) => Players.TryAdd(player.ObjectId, player);

        public Player GetPlayer(int x, int y)
        {
            foreach (var i in Players.Values)
                if (i.X == x && i.Y == y)
                    return i;
            return null;
        }

        public Player GetPlayer(int objId) => Players[objId];

        public void Add(GameObject entity) =>
            Chunks[new Point(entity.ChunkX, entity.ChunkY)].Add(entity);

        public void Remove(Player player)
        {
            if (!Players.TryRemove(player.ObjectId, out var disposedPlayer))
                disposedPlayer?.Dispose();
        }

        public void Dispose()
        {
            Players.Clear();
            Chunks.Clear();
            Tiles = null;
        }
    }
}