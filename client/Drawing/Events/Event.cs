using LoESoft.Client.Drawing.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace LoESoft.Client.Drawing.Events
{
    public enum Event : int
    {
        CLICKLEFT = 0,
        CLICKRIGT = 1,
        MOUSEOVER = 2,
        MOUSEOUT = 3,
    }

    public partial class EventsHandler
    {
        MouseState previousMouse;
        MouseState currentMouse;
        public static Rectangle MouseRectangle { get; private set; }
        
        public bool Handle(SpriteNode node, Event e)
        {
            previousMouse = currentMouse;
            currentMouse = Mouse.GetState();
            MouseRectangle = new Rectangle(currentMouse.X, currentMouse.Y, 3, 3);

            switch (e)
            {
                case Event.CLICKLEFT: return HandleMouseClickLeft(node);
                case Event.CLICKRIGT: return HandleMouseClickRight(node);
                case Event.MOUSEOVER: return HandleMouseOver(node);
                case Event.MOUSEOUT: return HandleMouseOut(node);
                default: return false;
            }
        }
    }
}
