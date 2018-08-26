using LoESoft.Client.Drawing.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Timers;

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

    public static class EventsManager
    {
        public static bool IsEventActive = false;

        public static void SetUnactive()
        {
            Timer timer = new Timer(100);
            timer.Elapsed += StopTimer;
            timer.Enabled = true;

            void StopTimer(object o, ElapsedEventArgs e)
            {
                IsEventActive = false;
                timer.Stop();
            }
        }
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

        float timer = 0f;
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
    }
}
