using LoESoft.Client.Drawing.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LoESoft.Client.Drawing.Events
{
    public enum Event : int
    {
        CLICKLEFT = 0,
        CLICKRIGT = 1,
        MOUSEOVER = 2,
        MOUSEOUT = 3,
        GETPRESSEDKEYS = 4,
        GETPRESSEDKEYSHOLDABLE = 5,
        HANDLEBACKSPACE = 6,
        CLICKOUTLEFT = 7
    }

    public partial class EventsHandler
    {
        MouseState previousMouse;
        MouseState currentMouse;
        public static Rectangle MouseRectangle { get; private set; }

        public bool HandleMouse(SpriteNode node, Event e)
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
                case Event.CLICKOUTLEFT: return HandleClickOutLeft(node);
                default: return false;
            }
        }

        KeyboardState previousKeyBoard;
        KeyboardState currentKeyBoard;

        public List<char> HandleKeyBoard(Event e)
        {
            previousKeyBoard = currentKeyBoard;
            currentKeyBoard = Keyboard.GetState();

            switch (e)
            {
                case Event.GETPRESSEDKEYS: return GetPressedKeys();
                //case Event.GETPRESSEDKEYSHOLDABLE: return GetPressedKeysHoldable();
                default: return null;
            }
        }
    }
}
