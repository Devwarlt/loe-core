using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LoESoft.Client.Core.Screens
{
    public sealed class ScreenManager
    {
        public static Screen ActiveScreen { get; set; }

        public static void DispatchScreen(Screen newScreen)
        {
            ActiveScreen?.OnScreenDispatch();
            newScreen.OnScreenCreate();
            ActiveScreen = newScreen;
        }

        public static void Update(GameTime gameTime)
        {
            if (ActiveScreen == null || !ActiveScreen.Visible)
                return;

            ActiveScreen.Update(gameTime);
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            if (ActiveScreen == null || !ActiveScreen.Visible)
                return;

            ActiveScreen.Draw(spriteBatch);
        }

        public static void Close()
        {
            ActiveScreen = null;
            _closeGame?.Invoke();
            Environment.Exit(0);
        }

        private static Action _closeGame;

        public static event Action CloseGame
        {
            add { _closeGame += value; }
            remove { _closeGame -= value; }
        }
    }
}