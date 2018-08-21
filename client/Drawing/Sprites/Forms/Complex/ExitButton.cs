using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoESoft.Client.Drawing.Events;
using Microsoft.Xna.Framework.Graphics;

namespace LoESoft.Client.Drawing.Sprites.Forms.Complex
{
    public class ExitButton : Sprite
    {
        public ExitButton(int x, int y, int width, int height, RGBColor color = null) 
            : base(x, y, width, height, DrawingSettings.GetTexture("exitImage"), color)
        {
            AddEventListener(Event.CLICKLEFT, onExit);
        }

        private void onExit(object sender, EventArgs e)
        {
            ParentSprite.ParentSprite.RemoveChild(ParentSprite);
        }
    }
}
