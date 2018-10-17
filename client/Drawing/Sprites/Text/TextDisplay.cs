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

        public static int GetHeight(int size) => (int)MeasureString("I", size).Y;

        public string Text { get; set; }
        public float Size { get; set; }
        public bool Bold { get; set; } //unhandled
        public int PerLineWidth { get; set; }
        public bool Outline { get; set; } // Test End

        public TextDisplay(int x, int y, string text, float size = 12, RGBColor color = null, float alpha = 1, bool bold = false)
            : base(x, y, 0, 0, null, color, alpha)
        {
            Text = text;
            Size = size;
            PerLineWidth = 0;
            Bold = bold;

            Width = (int)MeasureString(Text, (int)Size).X;
            Height = (int)MeasureString(Text, (int)Size).Y;
        }

        public static void LoadSpriteFont(ContentManager contentManager)
            => Font = AssetLoader.LoadAsset<SpriteFont>("fonts/font");

        public static Vector2 MeasureString(string text, int size = 12)
            => new Vector2(Font.MeasureString(text).X * (size / 100f), Font.MeasureString(text).Y * (size / 100f));

        public override void Update(GameTime gameTime) => base.Update(gameTime);

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (PerLineWidth != 0)
            {
                var offset = 0;
                foreach (var i in DetectPerLine())
                {
                    if (Outline) // Test
                    {
                        spriteBatch.DrawString(Font, i, new Vector2(StageX - Size / 100f, StageY + offset), Color.Black, 0f, Vector2.Zero, Size / 100f, SpriteEffects.None, 0f);
                        spriteBatch.DrawString(Font, i, new Vector2(StageX + Size / 100f, StageY + offset), Color.Black, 0f, Vector2.Zero, Size / 100f, SpriteEffects.None, 0f);
                        spriteBatch.DrawString(Font, i, new Vector2(StageX, StageY - Size / 100f + offset), Color.Black, 0f, Vector2.Zero, Size / 100f, SpriteEffects.None, 0f);
                        spriteBatch.DrawString(Font, i, new Vector2(StageX, StageY + Size / 100f + offset), Color.Black, 0f, Vector2.Zero, Size / 100f, SpriteEffects.None, 0f);
                    } // Test End

                    spriteBatch.DrawString(Font, i, new Vector2(StageX, StageY + offset), SpriteColor, 0f, Vector2.Zero, Size / 100f, SpriteEffects.None, 0f);
                    offset += GetHeight((int)Size) + 2;
                }
            }
            else
            {
                if (Outline) // Test
                {
                    spriteBatch.DrawString(Font, Text, new Vector2(StageX - Size / 100f, StageY), Color.Black, 0f, Vector2.Zero, Size / 100f, SpriteEffects.None, 0f);
                    spriteBatch.DrawString(Font, Text, new Vector2(StageX + Size / 100f, StageY), Color.Black, 0f, Vector2.Zero, Size / 100f, SpriteEffects.None, 0f);
                    spriteBatch.DrawString(Font, Text, new Vector2(StageX, StageY - Size / 100f), Color.Black, 0f, Vector2.Zero, Size / 100f, SpriteEffects.None, 0f);
                    spriteBatch.DrawString(Font, Text, new Vector2(StageX, StageY + Size / 100f), Color.Black, 0f, Vector2.Zero, Size / 100f, SpriteEffects.None, 0f);
                } // Test End

                spriteBatch.DrawString(Font, Text, new Vector2(StageX, StageY), SpriteColor, 0f, Vector2.Zero, Size / 100f, SpriteEffects.None, 0f);
            }

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

        private static IEnumerable<string> Split(string str, int chunkSize)
            => Enumerable.Range(0, str.Length / chunkSize).Select(i => str.Substring(i * chunkSize, chunkSize));
    }
}