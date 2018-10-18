using LoESoft.Client.Drawing.Sprites;
using Microsoft.Xna.Framework.Input;

namespace LoESoft.Client.Drawing.Events
{
    public static partial class EventsHandler
    {
        static bool HandleMouseClickLeft(SpriteNode node)
            => !node.Visible || !node.SpriteRectangle.Intersects(MouseRectangle) ? false
            : currentMouse.LeftButton == ButtonState.Released && previousMouse.LeftButton == ButtonState.Pressed;

        static bool HandleMouseClickRight(SpriteNode node)
            => !node.Visible || !node.SpriteRectangle.Intersects(MouseRectangle) ? false
            : currentMouse.RightButton == ButtonState.Released && previousMouse.RightButton == ButtonState.Pressed;

        static bool HandleClickOutLeft(SpriteNode node)
            => !node.Visible || node.SpriteRectangle.Intersects(MouseRectangle) ? false
            : currentMouse.LeftButton == ButtonState.Released && previousMouse.LeftButton == ButtonState.Pressed;

        static bool HandleMouseOver(SpriteNode node)
            => !node.Visible || !node.SpriteRectangle.Intersects(MouseRectangle) ? false : true;

        static bool HandleMouseOut(SpriteNode node)
            => !node.Visible || node.SpriteRectangle.Intersects(MouseRectangle) ? false : true;
    }
}