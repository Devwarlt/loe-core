using LoESoft.Client.Drawing.Sprites;
using Microsoft.Xna.Framework.Input;

namespace LoESoft.Client.Drawing.Events
{
    public partial class EventsHandler
    {
        protected bool HandleMouseClickLeft(SpriteNode node)
            => !node.Visible || !node.SpriteRectangle.Intersects(MouseRectangle) ? false
            : currentMouse.LeftButton == ButtonState.Released && previousMouse.LeftButton == ButtonState.Pressed;

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