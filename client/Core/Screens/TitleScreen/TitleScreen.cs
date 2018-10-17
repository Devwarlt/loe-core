using LoESoft.Client.Assets;
using LoESoft.Client.Core.Game;
using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Events;
using LoESoft.Client.Drawing.Sprites.Forms;
using LoESoft.Client.Drawing.Sprites.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace LoESoft.Client.Core.Screens
{
    public class TitleScreen : Screen
    {
        private TextDisplay Title { get; set; }
        private TextButton PlayButton { get; set; }
        private TextButton OptionsButton { get; set; }
        private TextButton ExitButton { get; set; }

        private RegisterPanel _registerPanel;
        private LoginPanel _loginPanel;
        private TextButton _registerButton;
        private TextButton _loginButton;

        private Mask _maskBlocker;

        private Texture2D BackgroundImage { get; set; }
        private FilledRectangle Background { get; set; }

        public List<Tile> Tiles { get; set; }
        public TitleScreen()
        {
            var buttonGap = 6;

            Title = new TextDisplay(0, 0, "BRME", 30, new RGBColor(255, 0, 0));
            Title.X = (GameApplication.WIDTH - Title.Width) / 2;
            Title.Y = Title.Height * 3;
            Title.Outline = true;

            _maskBlocker = new Mask(new RGBColor(Color.Black.R, Color.Black.G, Color.Black.B));

            _registerPanel = new RegisterPanel(((GameApplication.WIDTH - 400) / 2),
            ((GameApplication.HEIGHT - 250) / 2));

            _loginPanel = new LoginPanel(((GameApplication.WIDTH - 400) / 2),
            ((GameApplication.HEIGHT - 200) / 2));

            _registerPanel.OnPanelExit += _registerPanel_OnPanelExit;
            _loginPanel.OnPanelExit += _loginPanel_OnPanelExit;

            _registerButton = new TextButton("Register", 30);
            _registerButton.X = (GameApplication.WIDTH - _registerButton.Width) / 2;
            _registerButton.Y = (GameApplication.HEIGHT - _registerButton.Height) / 2;
            _registerButton.TextDisplay.Outline = true;

            _loginButton = new TextButton("Login", 30);
            _loginButton.X = (GameApplication.WIDTH - _loginButton.Width) / 2;
            _loginButton.Y = _registerButton.Y + _registerButton.Height + buttonGap;
            _loginButton.TextDisplay.Outline = true;

            PlayButton = new TextButton("Play", 30);
            PlayButton.X = (GameApplication.WIDTH - PlayButton.Width) / 2;
            PlayButton.Y = _loginButton.Y + _loginButton.Height + buttonGap;
            PlayButton.TextDisplay.Outline = true;

            OptionsButton = new TextButton("Options", 30);
            OptionsButton.X = (GameApplication.WIDTH - OptionsButton.Width) / 2;
            OptionsButton.Y = PlayButton.Y + PlayButton.Height + buttonGap;
            OptionsButton.TextDisplay.Outline = true;

            ExitButton = new TextButton("Exit", 30);
            ExitButton.X = (GameApplication.WIDTH - ExitButton.Width) / 2;
            ExitButton.Y = OptionsButton.Y + OptionsButton.Height + buttonGap;
            ExitButton.TextDisplay.Outline = true;

            _registerButton.AddEventListener(Event.CLICKLEFT, onRegisterPanel);
            _registerButton.AddEventListener(Event.MOUSEOUT, onRegisterOut);
            _registerButton.AddEventListener(Event.MOUSEOVER, onRegisterOver);

            _loginButton.AddEventListener(Event.CLICKLEFT, onLoginPanel);
            _loginButton.AddEventListener(Event.MOUSEOVER, onLoginOver);
            _loginButton.AddEventListener(Event.MOUSEOUT, onLoginOut);

            PlayButton.AddEventListener(Event.CLICKLEFT, OnPlay);
            PlayButton.AddEventListener(Event.MOUSEOVER, OnPlayButtonOver);
            PlayButton.AddEventListener(Event.MOUSEOUT, OnPlayButtonOut);

            OptionsButton.AddEventListener(Event.MOUSEOVER, OnOptionsButtonOver);
            OptionsButton.AddEventListener(Event.MOUSEOUT, OnOptionsButtonOut);

            ExitButton.AddEventListener(Event.CLICKLEFT, OnExit);
            ExitButton.AddEventListener(Event.MOUSEOVER, OnExitButtonOver);
            ExitButton.AddEventListener(Event.MOUSEOUT, OnExitButtonOut);
            

            BackgroundImage = AssetLoader.LoadAsset<Texture2D>("images/titleScreenBackground");

            Background = new FilledRectangle(BackgroundImage);
            Background.X = 0;
            Background.Y = 0;


            Background.AddEventListener(Event.CLICKLEFT, onTitle);

            Background.AddChild(Title);
            Background.AddChild(_registerButton);
            Background.AddChild(_loginButton);
            Background.AddChild(PlayButton);
            Background.AddChild(OptionsButton);
            Background.AddChild(ExitButton);
        }

        private void _loginPanel_OnPanelExit()
        {
            Background.RemoveChild(_maskBlocker);
        }

        private void _registerPanel_OnPanelExit()
        {
            Background.RemoveChild(_maskBlocker);
        }

        private void onTitle(object sender, EventArgs e)
        {
            GameClient.Info("TITLE");
        }

        private void onRegisterOver(object sender, EventArgs e) =>_registerButton.TextDisplay.SpriteColor = Color.Yellow;
        private void onRegisterOut(object sender, EventArgs e) => _registerButton.TextDisplay.SpriteColor = Color.White;
        

        private void onLoginOut(object sender, EventArgs e) => _loginButton.TextDisplay.SpriteColor = Color.White;
        private void onLoginOver(object sender, EventArgs e) => _loginButton.TextDisplay.SpriteColor = Color.Yellow;

        private void onLoginPanel(object sender, EventArgs e)
        {
            Background.AddChild(_maskBlocker);
            Background.AddChild(_loginPanel);
        }

        private void onRegisterPanel(object sender, EventArgs e)
        {
            Background.AddChild(_maskBlocker);
            Background.AddChild(_registerPanel);
        }

        private void OnPlayButtonOver(object sender, EventArgs e) => PlayButton.TextDisplay.SpriteColor = Color.Yellow;
        private void OnPlayButtonOut(object sender, EventArgs e) => PlayButton.TextDisplay.SpriteColor = Color.White;

        private void OnOptionsButtonOver(object sender, EventArgs e) => OptionsButton.TextDisplay.SpriteColor = Color.Yellow;
        private void OnOptionsButtonOut(object sender, EventArgs e) => OptionsButton.TextDisplay.SpriteColor = Color.White;

        private void OnExitButtonOver(object sender, EventArgs e) => ExitButton.TextDisplay.SpriteColor = Color.Yellow;
        private void OnExitButtonOut(object sender, EventArgs e) => ExitButton.TextDisplay.SpriteColor = Color.White;

        private void OnPlay(object sender, EventArgs e) => ScreenManager.DispatchScreen(new GameScreen());
        private void OnExit(object sender, EventArgs e) => ScreenManager.CloseGame();

        public override void OnScreenCreate() { }
        public override void OnScreenDispatch() { }

        private float TitleFlashSpeedR = 0;

        public override void Update(GameTime gameTime)
        {
            var dt = 1.0f / gameTime.ElapsedGameTime.Milliseconds;

            TitleFlashSpeedR += dt * 0.5f;

            Title.SpriteColor = Color.Lerp(Color.Red, Color.Yellow, (float)Math.Sin(TitleFlashSpeedR));

            Background.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            Background.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
