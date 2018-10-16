using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace LoESoft.Client.Core.Game.Objects
{
    public class BasicObject // test class
    {
        public float X { get; set; }
        public float Y { get; set; }
        public Texture2D Texture { get; set; }

        public float DrawX => X * 8;
        public float DrawY => Y * 8;
        public int Size = 8;

        public Color Color;

        public BasicObject(Color color) => Color = color;

        //TODO: need 2 implement a asset loader for the objects b4 the base class is done.
        public virtual void Update(GameTime gameTime) { }

        public virtual void Draw(SpriteBatch spriteBatch) => spriteBatch.DrawRectangle(new Rectangle((int)DrawX, (int)DrawY, Size, Size), Color, 4);
    }
}