using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoESoft.Client.Drawing.Events;
using LoESoft.Client.Drawing.Sprites.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoESoft.Client.Drawing.Sprites.Forms
{
    public class Button : Sprite
    {
        public TextDisplay NameText { get; set; }

        public Button(int x, int y, int width, int height, string name) 
            : base (x, y, width, height, DrawingSettings.GetTexture("btnImage"))
        {

            int textwidth = (int)TextDisplay.Font.MeasureString(name).X;
            NameText = new TextDisplay((width / 2 - textwidth / 2), 2, name, 12, new RGBColor(100, 100, 100), false);

            AddChild(NameText);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

    }
}
