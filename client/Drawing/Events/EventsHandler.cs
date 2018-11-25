using LoESoft.Client.Drawing.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace LoESoft.Client.Drawing.Events
{
    public partial class EventsHandler
    {
        private MouseState previousMouse;
        private MouseState currentMouse;

        public static Rectangle MouseRectangle { get; private set; }

        public bool HandleMouse(SpriteNode node, Event e)
        {
            previousMouse = currentMouse;
            currentMouse = Mouse.GetState();

            switch (e)
            {
                case Event.CLICKLEFT:
                    return HandleMouseClickLeft(node);

                case Event.CLICKRIGT:
                    return HandleMouseClickRight(node);

                case Event.MOUSEOVER:
                    return HandleMouseOver(node);

                case Event.MOUSEOUT:
                    return HandleMouseOut(node);

                case Event.CLICKOUTLEFT:
                    return HandleClickOutLeft(node);

                default:
                    return false;
            }
        }

        public static void Update() => MouseRectangle = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 5, 5);
    }
}