using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace LoESoft.Client.Drawing.Sprites.Forms
{
    public class FilledRectangle : Sprite
    {
        public FilledRectangle(int x, int y, int width, int height, RGBColor color = null)
            : base(x, y, width, height, null, color)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Visible)
                spriteBatch.FillRectangle(SpriteRectangle, SpriteColor);

            base.Draw(spriteBatch);
        }
    }
}
