using LoESoft.Client.Drawing.Sprites;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoESoft.Client.Drawing.Events
{
    public partial class EventsHandler
    {
        public bool HandleMouseClickLeft(SpriteNode node)
        {
            if (!node.Visible || !node.SpriteRectangle.Intersects(MouseRectangle))
                return false;

            if (!(currentMouse.LeftButton == ButtonState.Released && previousMouse.LeftButton == ButtonState.Pressed))
                return false;
            
            return true;
        }
    }
}
