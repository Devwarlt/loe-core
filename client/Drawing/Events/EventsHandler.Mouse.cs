using LoESoft.Client.Drawing.Sprites;
using Microsoft.Xna.Framework.Input;

namespace LoESoft.Client.Drawing.Events
{
    public partial class EventsHandler
    {
        protected bool HandleMouseClickLeft(SpriteNode node)
        {
            if (!node.Visible || !node.SpriteRectangle.Intersects(MouseRectangle))
                return false;

            if (!(currentMouse.LeftButton == ButtonState.Released && previousMouse.LeftButton == ButtonState.Pressed))
                return false;

            return true;
        }

        protected bool HandleMouseClickRight(SpriteNode node)
        {
            if (!node.Visible || !node.SpriteRectangle.Intersects(MouseRectangle))
                return false;

            if (!(currentMouse.RightButton == ButtonState.Released && previousMouse.RightButton == ButtonState.Pressed))
                return false;

            return true;
        }

        protected bool HandleMouseOver(SpriteNode node)
        {
            if (!node.Visible || !node.SpriteRectangle.Intersects(MouseRectangle))
                return false;

            return true;
        }

        protected bool HandleMouseOut(SpriteNode node)
        {
            if (node.Visible || !node.SpriteRectangle.Intersects(MouseRectangle))
                return false;

            return true;
        }
    }
}
