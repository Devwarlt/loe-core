using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoESoft.Client.Drawing.Sprites
{
    public class Sprite : SpriteNode
    {
        public Texture2D SpriteTexture { get; set; }
        public Color SpriteColor { get; set; }

        public Sprite(int x, int y, int width, int height, Texture2D texture = null, RGBColor color = null, float alpha = 1)
            : base(x, y, width, height)
        {
            SpriteTexture = texture;

            if (color == null)
                color = RGBColor.Default;

            SpriteColor = new Color(color.R, color.G, color.B, (byte) (255 * alpha));
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (SpriteTexture != null)
                spriteBatch.Draw(SpriteTexture, SpriteRectangle, SpriteColor);

            base.Draw(spriteBatch);
        }

        public static void AddOutline(ref Texture2D texture)
        {
            int w = texture.Width;
            int h = texture.Height;

            var color = new Color[w * h];

            texture.GetData(color);

            for (var i = 0; i < w * h; i++)
            {
                var c = color[i];

                if (c == Color.Transparent)
                {
                    try
                    {
                    }
                    catch { }
                }
            }
        }
    }
}