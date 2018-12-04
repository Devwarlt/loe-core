using LoESoft.Client.Drawing.Sprites;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace LoESoft.Client.Drawing.Events
{
    public partial class EventsHandler
    {
        protected bool HandleMouseClickLeft(SpriteNode node) => handleVisibleOrNull(node) ? false
            : currentMouse.LeftButton == ButtonState.Released && previousMouse.LeftButton == ButtonState.Pressed;

        protected bool HandleMouseClickRight(SpriteNode node) => handleVisibleOrNull(node) ? false
            : currentMouse.RightButton == ButtonState.Released && previousMouse.RightButton == ButtonState.Pressed;

        protected bool HandleClickOutLeft(SpriteNode node) => handleVisibleOrNull(node) ? false
            : currentMouse.LeftButton == ButtonState.Released && previousMouse.LeftButton == ButtonState.Pressed;

        protected bool HandleMouseOver(SpriteNode node) => handleVisibleOrNull(node) ? false : true;

        protected bool HandleMouseOut(SpriteNode node)
            => handleVisibleOrNull(node);
        
        private Stopwatch _holdLeftWatch = new Stopwatch();
        private Stopwatch _holdRightWatch = new Stopwatch();

        protected bool HandleMouseLeftHold(SpriteNode node)
        {
            if (handleVisibleOrNull(node))
                return false;

            if (previousMouse.LeftButton == ButtonState.Pressed && currentMouse.LeftButton == ButtonState.Pressed)
            {
                if (!_holdLeftWatch.IsRunning)
                    _holdLeftWatch.Start();

                if (_holdLeftWatch.ElapsedMilliseconds > 500)
                    return true;
            } else
            {
                _holdLeftWatch.Reset();
            }

            return false;
        }

        protected bool HandleMouseRightHold(SpriteNode node)
        {
            if (handleVisibleOrNull(node))
                return false;

            if (previousMouse.RightButton == ButtonState.Pressed && currentMouse.RightButton == ButtonState.Pressed)
            {
                if (!_holdRightWatch.IsRunning)
                    _holdRightWatch.Start();

                if (_holdRightWatch.ElapsedMilliseconds > 500)
                    return true;
            } else
            {
                _holdRightWatch.Reset();
            }

            return false;
        }

        private bool handleVisibleOrNull(SpriteNode node) => !node.Visible || !node.SpriteRectangle.Intersects(MouseRectangle);
    }
}