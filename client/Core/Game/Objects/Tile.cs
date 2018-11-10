using LoESoft.Client.Assets.Xml;
using LoESoft.Client.Assets.Xml.Structure;
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
        public int TileId { get; set; }

        public TilesContent TileProperties { get; set; }
        public Texture2D Texture { get; set; }

        public Tile(int x, int y, int id)
        {
            X = x;
            Y = y;
            TileId = id;
            TileProperties = XmlLibrary.TilesXml[TileId];
            Texture = XmlLibrary.GetSpriteFromContent(TileProperties);
        }

        public void Draw(SpriteBatch spriteBatch) => spriteBatch.Draw(Texture, new Rectangle(DrawX, DrawY, Texture.Width, Texture.Height), Color.White);
    }
}