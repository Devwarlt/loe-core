using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace LoESoft.Client.Drawing.Sprites
{
    public class Sprite : SpriteNode
    {
        public Texture2D SpriteTexture { get; private set; }
        public Color SpriteColor { get; private set; }

        public Sprite(int x, int y, int width, int height,
            Texture2D texture = null, uint color = 0xFFFFFF, int alpha = 1)
            : base(x, y, width, height)
        {
            SpriteTexture = texture;
            SpriteColor = new Color(new Color(color), 1);
        }

        public override void Update(GameTime gameTime) => base.Update(gameTime);

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            if (SpriteTexture != null)
                spriteBatch.Draw(SpriteTexture, SpriteRectangle, SpriteColor);
            else
                spriteBatch.DrawRectangle(SpriteRectangle, SpriteColor);
        }
    }
}
