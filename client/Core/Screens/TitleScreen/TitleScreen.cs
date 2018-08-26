using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Events;
using LoESoft.Client.Drawing.Sprites.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LoESoft.Client.Core.Screens
{
    public class TitleScreen : Screen
    {
        private Button RegisterBtn { get; set; }
        private Button LoginBtn { get; set; }
        private Button ExitBtn { get; set; }
        private Button PlayBtn { get; set; }

        private RegisterPanel RegisterPanel { get; set; }
        private LoginPanel LoginPanel { get; set; }

        private FilledRectangle BackGround { get; set; }

        public TitleScreen()
        {
            BackGround = new FilledRectangle(0, 0, GameApplication.WIDTH, GameApplication.HEIGHT, new RGBColor(0, 0, 0));
            RegisterBtn = new Button(10, 10, "Register", new RGBColor(0, 0, 255));
            LoginBtn = new Button(10, 40, "Login", new RGBColor(0, 0, 255));
            PlayBtn = new Button(10, 70, "Play", new RGBColor(0, 0, 255));
            ExitBtn = new Button(10, 100, "Close", new RGBColor(0, 0, 255));
            RegisterPanel = new RegisterPanel(100, 100);
            LoginPanel = new LoginPanel(100, 100);

            RegisterBtn.AddEventListener(Event.CLICKLEFT, BtnRegisterClicked);
            LoginBtn.AddEventListener(Event.CLICKLEFT, BtnLoginClicked);
            PlayBtn.AddEventListener(Event.CLICKLEFT, OnPlay);
            ExitBtn.AddEventListener(Event.CLICKLEFT, BtnExit);

            BackGround.AddChild(RegisterBtn);
            BackGround.AddChild(LoginBtn);
            BackGround.AddChild(PlayBtn);
            BackGround.AddChild(ExitBtn);
        }

        private void OnPlay(object sender, EventArgs e) => ScreenManager.DispatchScreen(new GameScreen());

        private void BtnLoginClicked(object sender, EventArgs e) => BackGround.AddChild(LoginPanel);

        private void BtnExit(object sender, EventArgs e) => ScreenManager.CloseGame();

        private void BtnRegisterClicked(object sender, EventArgs e) => BackGround.AddChild(RegisterPanel);

        public override void OnScreenCreate() { }
        public override void OnScreenDispatch() { }

        public override void Update(GameTime gameTime) => BackGround.Update(gameTime);

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            BackGround.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
