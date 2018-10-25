using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LoESoft.Client.Core.Screens
{
    public sealed class ScreenManager
    {
        public static Screen ActiveScreen { get; set; }

        private static Action DoCloseGame { get; set; }

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

        public static void CloseGame()
        {
            ActiveScreen = null;
            //DoCloseGame?.Invoke(); // not working!
            Environment.Exit(0);
        }

        public static event Action OnGameClose
        {
            add { DoCloseGame += value; }
            remove { DoCloseGame -= value; }
        }
    }
}