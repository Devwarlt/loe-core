using LoESoft.Client.Core.Game.Map.Data;
using LoESoft.Client.Core.Game.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoESoft.Client.Core.Game.Map
{
    public static class WorldMap
    {
        public static Dictionary<Point, Tile> TileMap { get; private set; }
        public static Dictionary<int, GameObject> Objects { get; private set; }

        public static int WIDTH { get; private set; } = 0;
        public static int HEIGHT { get; private set; } = 0;
        
        public static void Initialize(int w, int h)
        {
            TileMap = new Dictionary<Point, Tile>(w * h);
            Objects = new Dictionary<int, GameObject>();

            WIDTH = w;
            HEIGHT = h;
        }

        public static void AddOrUpdate(TileData[] tilesAddOrUpdate, ObjectData[] objAddOrUpdate, int[] removedObjects)
        {
            Task.Factory.StartNew(() =>
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
                                ((Entity)Objects[i.ObjectId]).CurrentDirection = (Direction)i.LastDirection;
                        }
                    }
                    else
                    {
                        if (i.IsPlayer)
                            HandlePlayer(i);
                        else if (i.IsEntity)
                            HandleEntity(i);
                        else
                            HandleObject(i);
                    }
                }
            });
        }

        private static void HandleObject(ObjectData data)
        {
            var obj = new GameObject(data.Id)
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

        private static void HandleEntity(ObjectData data)
        {
            var obj = new Entity(data.Id)
            {
                X = data.X,
                Y = data.Y,
                ObjectId = data.ObjectId,
                DistinationX = data.X,
                DistinationY = data.Y
            };

            obj.Init();
            obj.CurrentDirection = (Direction)data.LastDirection;
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

        public static void Update(GameTime gameTime)
        {
            foreach (var i in Objects)
                i.Value.Update(gameTime);
        }

        public static void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            foreach (var i in GetSightPoints(x, y))
                if (TileMap.ContainsKey(i))
                    TileMap[i].Draw(spriteBatch);

            foreach (var i in GetEntitiesInSight(x, y))
                i.Draw(spriteBatch);
        }

        public static HashSet<GameObject> GetEntitiesInSight(int x, int y) =>
            Objects.Where(_ => _.Value.X > x - SightRadius && _.Value.X < x + SightRadius
            && _.Value.Y > y - SightRadius && _.Value.Y < y + SightRadius).Select(_ => _.Value).ToHashSet();


        public static int SightDiameter = 21;
        public static int SightRadius = (SightDiameter - 1) / 2;

        public static HashSet<Point> GetSightPoints(int px, int py)
        {
            var points = new HashSet<Point>();

            for (var x = 0; x < SightDiameter; x++)
            {
                for (var y = 0; y < SightDiameter; y++)
                {
                    var newX = px + (x - SightRadius);
                    var newY = py + (y - SightRadius);

                    if (px >= 0 && px <= WIDTH && py >= 0 && py <= HEIGHT)
                        points.Add(new Point(newX, newY));
                }
            }

            return points;
        }
    }
}