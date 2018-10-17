using LoESoft.Client.Drawing.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LoESoft.Client.Drawing.Events
{
    public partial class EventsHandler
    {
        private float timer = 0f;

        private MouseState previousMouse;
        private MouseState currentMouse;
        private KeyboardState previousKeyBoard;
        private KeyboardState currentKeyBoard;

        public static Rectangle MouseRectangle { get; private set; }

        public bool HandleMouse(SpriteNode node, Event e)
        {
            previousMouse = currentMouse;
            currentMouse = Mouse.GetState();

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

        public bool HandleBackSpace(GameTime time)
        {
            if (previousKeyBoard.IsKeyDown(Keys.Back) && currentKeyBoard.IsKeyUp(Keys.Back))
                return true;
            else if (previousKeyBoard.IsKeyDown(Keys.Back) && currentKeyBoard.IsKeyDown(Keys.Back))
            {
                timer += time.ElapsedGameTime.Seconds;
                if (timer > 1f)
                    return true;

                if (currentKeyBoard.IsKeyUp(Keys.Back))
                    timer = 0f;
            }

            return false;
        }

        public static void Update() => MouseRectangle = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 3, 3);
    }
}