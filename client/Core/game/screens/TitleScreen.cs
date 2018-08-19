using LoESoft.Client.Drawing.Sprites.TextDisplay;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoESoft.Client.Core.game.screens
{
    class TitleScreen : IScreen
    {
        public ScreenType ScreenType => ScreenType.TitleScreen;

        TextDisplay textDisplay;

        public TitleScreen()
        {
            textDisplay = new TextDisplay(10, 10, "Test", 8);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            textDisplay.Draw(spriteBatch);
            spriteBatch.End();
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
