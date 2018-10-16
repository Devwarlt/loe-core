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
            newScreen.OnScreenCreate();
            ActiveScreen?.OnScreenDispatch();
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

        private static Action DoCloseGame { get; set; }

        public static void CloseGame()
        {
            ActiveScreen = null;
            DoCloseGame?.Invoke();
        }

        public static event Action OnGameClose
        {
            add { DoCloseGame += value; }
            remove { DoCloseGame -= value; }
        }
    }
}