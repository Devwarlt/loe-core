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
        public int TileType { get; set; }
        public TileProperties TileProperties { get; set; }

        public Tile(int x, int y, int type)
        {
            X = x;
            Y = y;
            TileType = type;
            TileProperties = TileLibrary.PropsLibrary[type];
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            //spriteBatch.Draw(TileProperties, new Vector2(X, Y), Color.White);
            spriteBatch.End();
        }
    }
}
