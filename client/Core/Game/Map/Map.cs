using LoESoft.Client.Core.Game.Map.Data;
using LoESoft.Client.Core.Game.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoESoft.Client.Core.Game.Map
{
    public static class Map
    {
        public static Tile[,] TileMap { get; set; }

        public static Dictionary<int, Entity> Objects { get; set; }

        public static int MapWidth { get; private set; }
        public static int MapHeight { get; private set; }

        private static bool _initialized = false;

        static Map()
        {
            Objects = new Dictionary<int, Entity>();
        }

        public static void Initialize(int w, int h)
        {
            TileMap = new Tile[w, h];
            MapWidth = w;
            MapHeight = h;

            _initialized = true;
        }

        public static void AddOrUpdate(TileData[] tilesAddOrUpdate, ObjectData[] objAddOrUpdate)
        {
            if (!_initialized)
                return;

            foreach (var i in tilesAddOrUpdate)
                TileMap[i.X, i.Y] = new Tile(i.X, i.Y, i.Id);

            foreach (var i in objAddOrUpdate)
            {
                if (Objects.ContainsKey(i.ObjectId))
                {
                    //Update stat
                    Objects[i.ObjectId].DistinationX = i.X;
                    Objects[i.ObjectId].DistinationY = i.Y;
                }
                else
                {
                    if (i.IsPlayer)
                    {
                        HandlePlayer(i);
                    } else
                    {
                        HandleEntity(i);
                    }
                }
            }
        }

        private static void HandleEntity(ObjectData data)
        {
            try
            {
                var obj = new EntityObject()
                {
                    X = data.X,
                    Y = data.Y,
                    DistinationX = data.X,
                    DistinationY = data.Y
                };
                obj.Init();
                Objects.Add(data.ObjectId, obj);
            }catch(Exception ex)
            {
                App.Warn(ex.ToString());
            }
        }

        private static void HandlePlayer(ObjectData data)
        {
            var player = new Player()
            {
                X = data.X,
                Y = data.Y,
                DistinationX = data.X,
                DistinationY = data.Y
            };
            player.Init();
            Objects.Add(data.ObjectId, player);
        }

        public static void Update(GameTime gameTime)
        {
            foreach (var i in Objects.ToArray())
                i.Value.Update(gameTime);
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            for (var w = 0; w < MapWidth; w++)
                for (var h = 0; h < MapHeight; h++)
                    if (TileMap[w, h] != null)
                        TileMap[w, h].Draw(spriteBatch);

            foreach (var i in Objects.ToArray())
                i.Value.Draw(spriteBatch);
        }
    }
}