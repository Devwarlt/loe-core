using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
    }
}
