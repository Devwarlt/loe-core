using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LoESoft.Client.Drawing.Sprites.Text
{
    public class TextDisplay : Sprite
    {
        public static SpriteFont Font { get; private set; }
        public static void LoadSpriteFont(ContentManager contentManager) =>
            Font = contentManager.Load<SpriteFont>("fonts/font");
        
        public string Text { get; set; }
        public float Size { get; set; }
        public bool Bold { get; set; } //unhandled

        public TextDisplay(int x, int y, string text, float size = 12, RGBColor color = null, bool bold = false)
            : base(x, y, 0, 0, null, color, 1)
        {
            Text = text;
            Size = size;
            Bold = bold;
        }
       
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            float scale = Size / 100f;

            spriteBatch.DrawString(Font, Text, new Vector2(X, Y), SpriteColor, 0f,
                Vector2.Zero, scale, SpriteEffects.None, 0f);
        }
    }
}
