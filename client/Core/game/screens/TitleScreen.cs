using LoESoft.Client.Drawing.Sprites.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoESoft.Client.Core.game.screens
{
    class TitleScreen : IScreen
    {
        public ScreenType ScreenType => ScreenType.TitleScreen;

        Button button;

        public TitleScreen()
        {
            button = new Button(10, 10, 100, 40, "Click me!");
        }

        public void Update(GameTime gameTime)
        {
            button.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            button.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
