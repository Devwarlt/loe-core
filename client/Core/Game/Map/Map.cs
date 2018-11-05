using LoESoft.Client.Core.Game.Map.Data;
using LoESoft.Client.Core.Game.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LoESoft.Client.Core.Game.Map
{
    public static class Map
    {
        public static Tile[,] TileMap { get; set; }
        
        public static List<Entity> Objects { get; set; }

        public static int MapWidth { get; private set; }
        public static int MapHeight { get; private set; }

        public static void Initialize(int w, int h)
        {
            TileMap = new Tile[w, h];
            MapWidth = w;
            MapHeight = h;
            Objects = new List<Entity>();
        }

        public static void AddOrUpdate(TileData[] tilesAddOrUpdate, ObjectData[] objAddOrUpdate)
        {
            foreach (var i in tilesAddOrUpdate)
                TileMap[i.X, i.Y] = new Tile(i.X, i.Y, i.Id);
        }

        public static void Update(GameTime gameTime)
        {
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            for (var w = 0; w < MapWidth; w++)
                for (var h = 0; h < MapHeight; h++)
                    if (TileMap[w, h] != null)
                        TileMap[w, h].Draw(spriteBatch);
        }
    }
}