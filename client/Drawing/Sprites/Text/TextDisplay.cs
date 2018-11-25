﻿using LoESoft.Client.Assets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoESoft.Client.Drawing.Sprites.Text
{
    public class TextDisplay : Sprite
    {
        public static SpriteFont Font { get; private set; }

        public static int GetHeight(int size) => (int)MeasureString("I", size).Y;

        public float Size { get; set; }
        public bool Bold { get; set; }
        public bool Outline { get; set; }

        private string _text;

        public string Text
        {
            get => _text;
            set
            {
                Width = (int)MeasureString(value, (int)Size).X;
                Height = (int)MeasureString(value, (int)Size).Y;

                _text = value;
            }
        }

        public  List<string> TextByLine;

        private int _warpwidth;
        public int WrapWidth
        {
            get => _warpwidth;
            set
            {
                _warpwidth = value;

                if (_warpwidth > 0)
                {
                    Text = WrapText(Text, WrapWidth);
                    detectLinePerString(_text);
                }
            }
        }

        public TextDisplay(int x, int y, string text, float size = 12, RGBColor color = null, float alpha = 1, bool bold = false)
            : base(x, y, 0, 0, null, color, alpha)
        {
            TextByLine = new List<string>();
            Size = size;
            Bold = bold;
            Text = text;
            TextHeight = GetHeight((int)size);
        }

        public static void LoadSpriteFont(ContentManager contentManager)
            => Font = AssetLoader.LoadAsset<SpriteFont>("fonts/font");

        public static Vector2 MeasureString(string text, int size = 12)
            => new Vector2(Font.MeasureString(text).X * (size / 100f), Font.MeasureString(text).Y * (size / 100f));

        //public static Vector2 MeasureString(string text, int size = 12, )

        public override void Update(GameTime gameTime)
        {
            if (TextByLine.Count > 0)
                TextHeight = (GetHeight((int)Size) * TextByLine.Count);
            else
                TextHeight = GetHeight((int)Size);
            base.Update(gameTime);
        }

        public int TextHeight { get; set; } 

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (TextByLine.Count > 0)
            {
                var offset = 0;

                foreach (var i in TextByLine)
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

        private void detectLinePerString(string text) => TextByLine = text.Split(new string[] { "/n" }, StringSplitOptions.None).ToList();
        
        public string WrapText(string text, float maxLineWidth)
        {
            string[] words = text.Split(' ');
            StringBuilder sb = new StringBuilder();
            float lineWidth = 0f;
            float spaceWidth = MeasureString(" ", (int)Size).X;

            foreach (string word in words)
            {
                Vector2 size = MeasureString(word, (int)Size);

                if (lineWidth + size.X < maxLineWidth)
                {
                    sb.Append(word + " ");
                    lineWidth += size.X + spaceWidth;
                }
                else
                {
                    sb.Append("\n" + word + " ");
                    lineWidth = size.X + spaceWidth;
                }
            }

            return sb.ToString();
        }
    }
}