using LoESoft.Client.Core.Game.Map.Data;
using LoESoft.Client.Core.Game.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoESoft.Client.Core.Game.Map
{
    public static class WorldMap
    {
        public class ValuePair
        {
            public Entity Entity;
            public Point Pos;
        }
        public static Dictionary<Point, Tile> TileMap;

        public static Dictionary<int, ValuePair> Objects { get; set; }

        public static int MapWidth { get; private set; }
        public static int MapHeight { get; private set; }

        public static bool MapLoaded { get; set; }

        static WorldMap()
        {
            Objects = new Dictionary<int, ValuePair>();
            MapLoaded = false;
        }

        public static void Initialize(int w, int h)
        {
            TileMap = new Dictionary<Point, Tile>(w * h);
            MapWidth = w;
            MapHeight = h;

            MapLoaded = true;
        }

        public static void AddOrUpdate(TileData[] tilesAddOrUpdate, ObjectData[] objAddOrUpdate)
        {
            foreach(var i in tilesAddOrUpdate)
            {
                var pos = new Point(i.X, i.Y);
                var tile = new Tile(pos.X, pos.Y, i.Id);

                if (TileMap.ContainsKey(pos))
                    TileMap[pos] = tile;
                else
                    TileMap.Add(pos, tile);
            }

            foreach (var i in objAddOrUpdate)
            {
                if (Objects.ContainsKey(i.ObjectId))
                {
                    Objects[i.ObjectId].Entity.DistinationX = i.X;
                    Objects[i.ObjectId].Entity.DistinationY = i.Y;
                    Objects[i.ObjectId].Pos.X = i.X;
                    Objects[i.ObjectId].Pos.Y = i.X;
                }
                else
                {
                    if (i.IsPlayer)
                        HandlePlayer(i);
                    else
                        HandleEntity(i);
                }
            }
        }

        private static void HandleEntity(ObjectData data)
        {
            var pos = new Point(data.X, data.Y);
            var obj = new EntityObject(data.Id)
            {
                X = pos.X,
                Y = pos.Y,
                DistinationX = pos.X,
                DistinationY = pos.Y
            };

            var pair = new ValuePair()
            {
                Pos = pos,
                Entity = obj
            };

            obj.Init();
            Objects.Add(data.ObjectId, pair);

            App.Warn($"Entity Added {pos.X} {pos.Y}");
        }

        private static void HandlePlayer(ObjectData data)
        {
            var pos = new Point(data.X, data.Y);
            var player = new Player(6)
            {
                X = pos.X,
                Y = pos.Y,
                DistinationX = pos.X,
                DistinationY = pos.Y
            };

            var pair = new ValuePair()
            {
                Pos = pos,
                Entity = player
            };

            player.Init();
            Objects.Add(data.ObjectId, pair);
        }
        
        public static void Update(GameTime gameTime)
        {
            if (!MapLoaded)
                return;

            foreach (var i in Objects.ToArray())
                i.Value.Entity.Update(gameTime);
        }
        
        public static void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            if (!MapLoaded)
                return;

            var sight = GetSightPoints(x, y);
            foreach (var i in sight)
            {
                if (TileMap.ContainsKey(i))
                    TileMap[i].Draw(spriteBatch);
            }

            foreach (var i in Objects.Where(_ => sight.Contains(_.Value.Pos)))
                i.Value.Entity.Draw(spriteBatch);
        }

        public static Point[] GetSightPoints(int X, int Y)
        {
            var points = new List<Point>();

            for (var x = -30; x < 30; x++)
                for (var y = -30; y < 30; y++)
                {
                    var sx = x * x;
                    var sy = y * y;

                    if (sx + sy <= 30)
                        points.Add(new Point(x + X, y + Y));
                }

            return points.ToArray();
        }
    }
}