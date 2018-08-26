using LoESoft.Client.Assets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace LoESoft.Client.Drawing.Sprites.Text
{
    public class TextDisplay : Sprite
    {
        public static SpriteFont Font { get; private set; }
        public static void LoadSpriteFont(ContentManager contentManager) => Font = AssetLoader.LoadAsset<SpriteFont>("fonts/font");

        public static int GetHeight(int size) => (int)MeasureString("I", size).Y;
        public static Vector2 MeasureString(string text, int size = 12)
        {
            float scale = size / 100f;

            float x = Font.MeasureString(text).X * scale;
            float y = Font.MeasureString(text).Y * scale;

            return new Vector2(x, y);
        }

        public string Text { get; set; }
        public float Size { get; set; }
        public bool Bold { get; set; } //unhandled
        public int PerLineWidth { get; set; }

        public TextDisplay(int x, int y, string text, float size = 12, RGBColor color = null, float alpha = 1, bool bold = false)
            : base(x, y, 0, 0, null, color, alpha)
        {
            Text = text;
            Size = size;
            PerLineWidth = 0;
            Bold = bold;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Width = (int)MeasureString(Text, (int)Size).X;
            Height = (int)MeasureString(Text, (int)Size).Y;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            var scale = Size / 100f;

            if (PerLineWidth != 0)
            {
                var offset = 0;
                foreach (var i in DetectPerLine())
                {
                    spriteBatch.DrawString(Font, i, new Vector2(StageX, StageY + offset), SpriteColor, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
                    offset += GetHeight((int)Size) + 2;
                }
            }
            else
                spriteBatch.DrawString(Font, Text, new Vector2(StageX, StageY), SpriteColor, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);

            base.Draw(spriteBatch);
        }

        private List<string> DetectPerLine()
        {
            if (PerLineWidth == 0)
                return null;

            var cWidth = 0;
            var cSize = 0;
            foreach (var i in Text)
            {
                cWidth += (int)MeasureString(i.ToString(), (int)Size).X;
                if (cWidth >= PerLineWidth)
                    break;
                cSize++;
            }

            return Split(Text, cSize).ToList();
        }

        private static IEnumerable<string> Split(string str, int chunkSize) => Enumerable.Range(0, str.Length / chunkSize).Select(i => str.Substring(i * chunkSize, chunkSize));
    }
}
