﻿using LoESoft.Server.Core.World.Entities;
using LoESoft.Server.Core.World.Entities.Player;
using LoESoft.Server.Core.World.Map;
using LoESoft.Server.Utils;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace LoESoft.Server.Core.World
{
    public class WorldMap
    {
        public const int WIDTH = 128;
        public const int HEIGHT = 128;

        public WorldManager Manager { get; set; }

        public Tile[,] Tiles { get; private set; }
        public Dictionary<Point, Chunk> Chunks { get; private set; }
        public ConcurrentDictionary<int, Player> Players { get; private set; }

        private bool _loaded = false;

        public WorldMap(WorldManager manager)
        {
            Manager = manager;

            Chunks = new Dictionary<Point, Chunk>();
            Players = new ConcurrentDictionary<int, Player>();

            //var map = Map.Structure.Map.GetMapByName("loemap.lsmap");

            Tiles = new Tile[WIDTH, HEIGHT];

            for (var x = 0; x < WIDTH; x++)
                for (var y = 0; y < HEIGHT; y++)
                    Tiles[x, y] = new Tile(Manager, 1016) { X = x, Y = y };

            var entrypoint = new Point(0, 0);

            Chunks.Add(entrypoint, new Chunk(Manager, 0, 0));

            Chunks[entrypoint].RandomGen();

            _loaded = true;

            App.Warn("Map Initialized!");
        }

        public void Update(WorldTime time)
        {
            if (_loaded)
            {
                foreach (var i in Chunks.Values)
                    i.Update(time);

                foreach (var i in Players.Values)
                    i.Update();
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