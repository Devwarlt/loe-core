using System;
using LoESoft.Client.Assets;
using LoESoft.Client.Core.game.ui.titlescreen;
using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Sprites.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoESoft.Client.Core.game.screens
{
    class TitleScreen : IScreen
    {
        public ScreenType ScreenType => ScreenType.TitleScreen;

        Button button;
        RegisterPanel panel;

        public TitleScreen()
        {
            button = new Button(10, 10, "Basic Button", new RGBColor(0, 0, 255));
            panel = new RegisterPanel(100, 100);

            button.AddEventListener(Drawing.Events.Event.CLICKLEFT, btnClicked);
        }

        private void btnClicked(object sender, EventArgs e)
        {
            button.AddChild(panel);
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
