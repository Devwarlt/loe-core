using LoESoft.Server.Core.Networking;
using LoESoft.Server.Core.World.Entities;
using LoESoft.Server.Core.World.Entities.Player;
using LoESoft.Server.Core.World.Map;
using LoESoft.Server.Core.World.Map.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace LoESoft.Server.Core.World
{
    public class WorldMap
    {
        public WorldManager Manager { get; set; }

        public Tile[,] Tiles { get; private set; }
        public Dictionary<Tuple<int, int>, Chunk> Chunks { get; private set; }

        public WorldMap(WorldManager manager)
        {
            Manager = manager;

            Tiles = new Tile[160, 160];
            Chunks = new Dictionary<Tuple<int, int>, Chunk>();
            Players = new List<Player>();
            Entities = new ConcurrentBag<Entity>();

            //Temporary Initiazation 
            var rand = new Random();
            for (var x = 0; x < 160; x++)
                for (var y = 0; y < 160; y++)
                {
                    var key = new Tuple<int, int>(x / Chunk.SIZE, y / Chunk.SIZE);

                    if (!Chunks.ContainsKey(key))
                        Chunks.Add(key, new Chunk(Manager, key.Item1, key.Item2));

                    Tiles[x, y] = new Tile(rand.Next(0, 4)) { X = x, Y = y };

                    Chunks[key].Add(new Entity(Manager, 0));
                }
        }

        public List<Player> Players { get; set; }
        public ConcurrentBag<Entity> Entities { get; private set; }

        public void Update(GameTime time)
        {
            if (Entities.Count > 0)
            {
                if (Entities.TryTake(out var entity))
                    Chunks[new Tuple<int, int>(entity.ChunkX, entity.ChunkY)].Add(entity);
            }
            
            foreach (var i in Chunks.Values)
                i.Update();

            foreach (var i in Players.ToArray())
                i.Update();
        }

        public bool IsValidPosition(int x, int y) => (x >= 0 && x <= 160 && y >= 0 && y <= 160);
        
        public void Add(Player player) => Players.Add(player);
        public void Add(Entity entity) => Entities.Add(entity);
        public void Remove(Player player) => Players.Remove(player);

        public void Dispose()
        {
            Players.Clear();
            Chunks.Clear();
            Tiles = null;
            Entities = null;
        }
    }
}