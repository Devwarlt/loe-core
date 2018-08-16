using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace LoESoft.Client.Drawing.Sprites
{
    public class Sprite : SpriteNode
    {
        public Sprite(int x, int y, int width, int height)
            : base (x, y, width, height)
        {
        }
        
        public override void Update(GameTime gameTime) => base.Update(gameTime);

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            spriteBatch.DrawRectangle(SpriteRectangle, Color.Black);
        }
    }
}
