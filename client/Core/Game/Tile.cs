using LoESoft.Client.Assets;
using LoESoft.Client.Assets.Properties;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoESoft.Client.Core.Game
{
    public class Tile
    {
        public const int TILE_SIZE = 8;

        public int X { get; set; }
        public int Y { get; set; }
        public int DrawX => X * TILE_SIZE;
        public int DrawY => Y * TILE_SIZE;
        public int TileType { get; set; }
        public TileProperties TileProperties { get; set; }
        public Texture2D Texture { get; set; }

        private int TextureOffsetX { get; set; }
        private int TextureOffsetY { get; set; }

        public Tile(int x, int y, int type)
        {
            X = x;
            Y = y;
            TileType = type;
            TileProperties = TileLibrary.PropsLibrary[type];
            Texture = AssetLibrary.Images[TileProperties.TextureFile];

            TextureOffsetX = TileProperties.TextureIndex % TILE_SIZE * TILE_SIZE;
            TextureOffsetY = TileProperties.TextureIndex / TILE_SIZE * TILE_SIZE;
        }

        public void Draw(SpriteBatch spriteBatch) => spriteBatch.Draw(Texture, new Vector2(DrawX, DrawY), new Rectangle(TextureOffsetX, TextureOffsetY, TILE_SIZE, TILE_SIZE), Color.White);
    }
}
