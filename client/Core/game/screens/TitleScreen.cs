using System;
using LoESoft.Client.Core.game.ui.titlescreen;
using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Events;
using LoESoft.Client.Drawing.Sprites.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoESoft.Client.Core.game.screens
{
    class TitleScreen : IScreen
    {
        public ScreenType ScreenType => ScreenType.TitleScreen;

        Button registerBtn;
        Button loginBtn;
        Button exitBtn;
        Button playBtn;

        RegisterPanel registerPanel;
        LoginPanel loginPanel;

        FilledRectangle backGround;

        public TitleScreen()
        {
            backGround = new FilledRectangle(0, 0, 600, 600, new RGBColor(0, 0, 0));
            registerBtn = new Button(10, 10, "Register", new RGBColor(0, 0, 255));
            loginBtn = new Button(10, 40, "Login", new RGBColor(0, 0, 255));
            playBtn = new Button(10, 70, "Play", new RGBColor(0, 0, 255));
            exitBtn = new Button(10, 100, "Close", new RGBColor(0, 0, 255));
            registerPanel = new RegisterPanel(100, 100);
            loginPanel = new LoginPanel(100, 100);

            registerBtn.AddEventListener(Event.CLICKLEFT, btnRegisterClicked);
            loginBtn.AddEventListener(Event.CLICKLEFT, btnLoginClicked);
            playBtn.AddEventListener(Event.CLICKLEFT, onPlay);
            exitBtn.AddEventListener(Event.CLICKLEFT, btnExit);

            backGround.AddChild(registerBtn);
            backGround.AddChild(loginBtn);
            backGround.AddChild(playBtn);
            backGround.AddChild(exitBtn);
        }

        private void onPlay(object sender, EventArgs e)
        {
            ScreenManager.ChangeScreen(ScreenType.WorldScreen);
        }

        private void btnLoginClicked(object sender, EventArgs e)
        {
            backGround.AddChild(loginPanel);
        }

        private void btnExit(object sender, EventArgs e) => ScreenManager.CloseGame();

        private void btnRegisterClicked(object sender, EventArgs e)
        {
            backGround.AddChild(registerPanel);
        }

        public void Update(GameTime gameTime)
        {
            backGround.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            backGround.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
