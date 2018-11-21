using LoESoft.Client.Core.Game.Map.Data;
using LoESoft.Client.Core.Game.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using static LoESoft.Client.Core.Game.Objects.Player;

namespace LoESoft.Client.Core.Game.Map
{
    public static class WorldMap
    {
        public class ValuePair
        {
            public Entity Entity;
            public Point Pos;
        }

        public static Dictionary<Point, Tile> TileMap { get; private set; }

        public static Dictionary<int, ValuePair> Objects { get; private set; }

        public static int WIDTH { get; private set; }
        public static int HEIGHT { get; private set; }

        public static bool MapLoaded { get; set; }

        static WorldMap()
        {
            Objects = new Dictionary<int, ValuePair>();
            MapLoaded = false;
        }

        public static void Initialize(int w, int h)
        {
            TileMap = new Dictionary<Point, Tile>(w * h);

            WIDTH = w;
            HEIGHT = h;

            MapLoaded = true;
        }

        public static void AddOrUpdate(TileData[] tilesAddOrUpdate, ObjectData[] objAddOrUpdate)
        {
            foreach (var i in tilesAddOrUpdate)
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
                    Objects[i.ObjectId].Entity.SetDistination(i.X, i.Y);
                    Objects[i.ObjectId].Pos.X = i.X;
                    Objects[i.ObjectId].Pos.Y = i.X;
                    Objects[i.ObjectId].Entity.ImportStat(i.Stats);
                    if (i.LastDirection != -1)
                        (Objects[i.ObjectId].Entity as Player).CurrentDirection = (Direction)i.LastDirection;
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
                ObjectId = data.ObjectId,
                DistinationX = pos.X,
                DistinationY = pos.Y
            };

            obj.Init();
            obj.ImportStat(data.Stats);
            Objects.Add(data.ObjectId, new ValuePair()
            {
                Pos = pos,
                Entity = obj
            });
        }

        private static void HandlePlayer(ObjectData data)
        {
            var pos = new Point(data.X, data.Y);
            var player = new Player(data.Id)
            {
                X = pos.X,
                Y = pos.Y,
                ObjectId = data.ObjectId,
                DistinationX = pos.X,
                DistinationY = pos.Y
            };

            player.Init();
            player.CurrentDirection = (Direction)data.LastDirection;
            player.ImportStat(data.Stats);

            Objects.Add(data.ObjectId, new ValuePair()
            {
                Pos = pos,
                Entity = player
            });
        }

        public static void Update(GameTime gameTime, int x, int y)
        {
            if (!MapLoaded)
                return;

            var sight = GetSightPoints(x, y);

            foreach (var i in Objects.Where(_ => sight.Contains(_.Value.Pos)))
                i.Value.Entity.Update(gameTime);
        }

        public static void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            if (!MapLoaded)
                return;

            var sight = GetSightPoints(x, y);

            foreach (var i in sight)
                if (TileMap.ContainsKey(i))
                    TileMap[i].Draw(spriteBatch);

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

                    if (sx + sy <= 30 && (x + X >= 0 && x + X < WIDTH) &&
                        (y + Y >= 0 && y + Y < HEIGHT))
                        points.Add(new Point(x + X, y + Y));
                }

            return points.ToArray();
        }
    }
}