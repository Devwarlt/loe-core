using LoESoft.Client.Drawing.Sprites;
using Microsoft.Xna.Framework.Input;

namespace LoESoft.Client.Drawing.Events
{
    public partial class EventsHandler
    {
        protected bool HandleMouseClickLeft(SpriteNode node)
        {
            if (!node.Visible || !node.SpriteRectangle.Intersects(EventsManager.MouseRect))
                return false;

            if (!(currentMouse.LeftButton == ButtonState.Released && previousMouse.LeftButton == ButtonState.Pressed))
                return false;

            return true;
        }

        protected bool HandleMouseClickRight(SpriteNode node)
        {
            if (!node.Visible || !node.SpriteRectangle.Intersects(EventsManager.MouseRect))
                return false;

            if (!(currentMouse.RightButton == ButtonState.Released && previousMouse.RightButton == ButtonState.Pressed))
                return false;

            return true;
        }

        protected bool HandleClickOutLeft(SpriteNode node)
        {
            if (!node.Visible || node.SpriteRectangle.Intersects(EventsManager.MouseRect))
                return false;

            if (!(currentMouse.LeftButton == ButtonState.Released && previousMouse.LeftButton == ButtonState.Pressed))
                return false;

            return true;
        }

        protected bool HandleMouseOver(SpriteNode node)
        {
            if (!node.Visible || !node.SpriteRectangle.Intersects(EventsManager.MouseRect))
                return false;
            return true;
        }

        protected bool HandleMouseOut(SpriteNode node)
        {
            if (!node.Visible || node.SpriteRectangle.Intersects(EventsManager.MouseRect))
                return false;
            return true;
        }

        protected bool HandleMouseClickRight(SpriteNode node)
            => !node.Visible || !node.SpriteRectangle.Intersects(MouseRectangle) ? false
            : currentMouse.RightButton == ButtonState.Released && previousMouse.RightButton == ButtonState.Pressed;

        protected bool HandleClickOutLeft(SpriteNode node)
            => !node.Visible || node.SpriteRectangle.Intersects(MouseRectangle) ? false
            : currentMouse.LeftButton == ButtonState.Released && previousMouse.LeftButton == ButtonState.Pressed;

        protected bool HandleMouseOver(SpriteNode node)
            => !node.Visible || !node.SpriteRectangle.Intersects(MouseRectangle) ? false : true;

        protected bool HandleMouseOut(SpriteNode node)
            => !node.Visible || node.SpriteRectangle.Intersects(MouseRectangle) ? false : true;
    }
}