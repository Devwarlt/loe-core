﻿using LoESoft.Client.Assets;
using LoESoft.Client.Drawing.Sprites.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoESoft.Client.Drawing.Sprites.Forms
{
    public class Button : Sprite
    {
        public TextDisplay NameText { get; set; }

        public Button(int x, int y, string name, RGBColor color = null, float alpha = 1)
            : base(x, y, 0, 0, AssetLibrary.Images["btnImage"], color, alpha)
        {
            NameText = new TextDisplay(5, 5, name);
            NameText.IsEventApplicable = false;
            Width = (int)TextDisplay.MeasureString(name).X + 10;
            Height = (int)TextDisplay.MeasureString(name).Y + 10;
            AddChild(NameText);
        }

        public override void Draw(SpriteBatch spriteBatch) => base.Draw(spriteBatch);

        public override void Update(GameTime gameTime) => base.Update(gameTime);
    }
}