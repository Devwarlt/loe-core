using LoESoft.Client.Core.Game.Map.Data;
using LoESoft.Client.Core.Game.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace LoESoft.Client.Core.Game.Map
{
    public static class WorldMap
    {
        public static Dictionary<Point, Tile> TileMap { get; private set; }
        public static Dictionary<int, Entity> Objects { get; private set; }

        public static int WIDTH { get; private set; }
        public static int HEIGHT { get; private set; }

        public static bool MapLoaded { get; set; }

        static WorldMap()
        {
            Objects = new Dictionary<int, Entity>();
            MapLoaded = false;
        }

        public static void Initialize(int w, int h)
        {
            TileMap = new Dictionary<Point, Tile>(w * h);

            WIDTH = w;
            HEIGHT = h;

            MapLoaded = true;
        }

        public static void AddOrUpdate(TileData[] tilesAddOrUpdate, ObjectData[] objAddOrUpdate, int[] removedObjects)
        {
            foreach (var i in removedObjects)
                Objects.Remove(i);

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
                    Objects[i.ObjectId].SetDistination(i.X, i.Y);
                    Objects[i.ObjectId].ImportStat(i.Stats);

                    if (i.LastDirection != -1)
                    {
                        if (Objects[i.ObjectId] is Player)
                            ((Player)Objects[i.ObjectId]).CurrentDirection = (Direction)i.LastDirection;
                        else
                            ((EntityObject)Objects[i.ObjectId]).CurrentDirection = (Direction)i.LastDirection;
                    }
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
            var obj = new EntityObject(data.Id)
            {
                X = data.X,
                Y = data.Y,
                ObjectId = data.ObjectId,
                DistinationX = data.X,
                DistinationY = data.Y
            };

            obj.Init();
            obj.ImportStat(data.Stats);
            Objects.Add(data.ObjectId, obj);
        }

        private static void HandlePlayer(ObjectData data)
        {
            var player = new Player(data.Id)
            {
                X = data.X,
                Y = data.Y,
                ObjectId = data.ObjectId,
                DistinationX = data.X,
                DistinationY = data.Y
            };

            player.Init();
            player.CurrentDirection = (Direction)data.LastDirection;
            player.ImportStat(data.Stats);

            Objects.Add(data.ObjectId, player);
        }

        public static void Update(GameTime gameTime, int x, int y)
        {
            if (!MapLoaded)
                return;

            foreach (var i in GetEntitiesInSight(x, y))
                i.Update(gameTime);
        }

        public static void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            if (!MapLoaded)
                return;

            foreach (var i in GetTilesInSight(x, y))
                i.Draw(spriteBatch);

            foreach (var i in Objects)
                i.Value.Draw(spriteBatch);
        }

        public static HashSet<Tile> GetTilesInSight(int x, int y)
        {
            var sight = GetSightPoints(x, y);

            return TileMap.Where(_ => sight.Contains(_.Key)).Select(_ => _.Value).ToHashSet();
        }

        public static HashSet<Entity> GetEntitiesInSight(int x, int y) =>
            Objects.Where(_ => _.Value.X > x - SightRadius && _.Value.X < x + SightRadius
            && _.Value.Y > y - SightRadius && _.Value.Y < y + SightRadius).Select(_ => _.Value).ToHashSet();
        

        public static int SightRadius = 10;
        public static int SightBound = SightRadius * 2;

        public static HashSet<Point> GetSightPoints(int X, int Y)
        {
            var points = new HashSet<Point>();

            for (var x = -SightRadius; x < SightRadius; x++)
                for (var y = -SightRadius; y < SightRadius; y++)
                {
                    var px = X + x;
                    var py = Y + y;

                    if (px >= 0 && px <= WIDTH && py >= 0 && py <= HEIGHT)
                        points.Add(new Point(px, py));
                }

            return points;
        }
    }
}