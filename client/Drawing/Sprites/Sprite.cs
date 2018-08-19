using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoESoft.Client.Drawing.Sprites
{
    public class Sprite : SpriteNode
    {
        public Texture2D SpriteTexture { get; private set; }
        public Color SpriteColor { get; private set; }

        public Sprite(int x, int y, int width, int height,
            Texture2D texture = null, RGBColor color = null, int alpha = 1)
            : base(x, y, width, height)
        {
            SpriteTexture = texture;

            if (color == null)
                color = new RGBColor(135, 135, 135);

            SpriteColor = new Color(color.R, color.G, color.B, alpha);
        }

        public override void Update(GameTime gameTime) => base.Update(gameTime);

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            if (SpriteTexture != null)
                spriteBatch.Draw(SpriteTexture, SpriteRectangle, SpriteColor);
        }
    }
}
