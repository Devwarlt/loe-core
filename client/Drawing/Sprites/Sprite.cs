using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoESoft.Client.Drawing.Sprites
{
    public class Sprite : SpriteNode
    {
        public Texture2D SpriteTexture { get; private set; }
        public Color SpriteColor { get; private set; }

        public Sprite(int x, int y, int width, int height,
            Texture2D texture = null, RGBColor color = null, float alpha = 1)
            : base(x, y, width, height)
        {
            SpriteTexture = texture;

            byte opacity = (byte)(255 * alpha);

            if (color == null)
                color = RGBColor.Default();

            SpriteColor = new Color(color.R, color.G, color.B, opacity);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (SpriteTexture != null)
                spriteBatch.Draw(SpriteTexture, SpriteRectangle, SpriteColor);

            base.Draw(spriteBatch);
        }
    }
}
