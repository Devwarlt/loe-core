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
        public List<Tile> Tiles { get; set; }

        private float TitleFlashSpeedR = 0;

        private TextDisplay Title { get; set; }
        private TextButton PlayButton { get; set; }
        private TextButton OptionsButton { get; set; }
        private TextButton ExitButton { get; set; }
        private FilledRectangle Background { get; set; }
        private RegisterPanel RegisterPanel;
        private LoginPanel LoginPanel;
        private TextButton RegisterButton;
        private TextButton LoginButton;
        private readonly Mask MaskBlocker;

        public TitleScreen()
        {
            Title = new TextDisplay(0, 0, "BRME", 30, new RGBColor(255, 0, 0));
            Title.X = (GameApplication.WIDTH - Title.Width) / 2;
            Title.Y = Title.Height * 3;
            Title.Outline = true;

            MaskBlocker = new Mask(new RGBColor(Color.Black.R, Color.Black.G, Color.Black.B));

            LoginPanel = new LoginPanel(((GameApplication.WIDTH - 400) / 2), ((GameApplication.HEIGHT - 200) / 2));
            LoginPanel.OnPanelExit += _loginPanel_OnPanelExit;

            RegisterPanel = new RegisterPanel(((GameApplication.WIDTH - 400) / 2), ((GameApplication.HEIGHT - 250) / 2));
            RegisterPanel.OnPanelExit += _registerPanel_OnPanelExit;

            RegisterButton = new TextButton("Register", 30);
            RegisterButton.X = (GameApplication.WIDTH - RegisterButton.Width) / 2;
            RegisterButton.Y = (GameApplication.HEIGHT - RegisterButton.Height) / 2;
            RegisterButton.TextDisplay.Outline = true;
            RegisterButton.AddEventListener(Event.CLICKLEFT, OnRegisterPanel);
            RegisterButton.AddEventListener(Event.MOUSEOUT, OnRegisterOut);
            RegisterButton.AddEventListener(Event.MOUSEOVER, OnRegisterOver);

            LoginButton = new TextButton("Login", 30);
            LoginButton.X = (GameApplication.WIDTH - LoginButton.Width) / 2;
            LoginButton.Y = RegisterButton.Y + RegisterButton.Height + 6;
            LoginButton.TextDisplay.Outline = true;
            LoginButton.AddEventListener(Event.CLICKLEFT, OnLoginPanel);
            LoginButton.AddEventListener(Event.MOUSEOVER, OnLoginOver);
            LoginButton.AddEventListener(Event.MOUSEOUT, OnLoginOut);

            PlayButton = new TextButton("Play", 30);
            PlayButton.X = (GameApplication.WIDTH - PlayButton.Width) / 2;
            PlayButton.Y = (GameApplication.HEIGHT - PlayButton.Height) / 2;
            PlayButton.Y = LoginButton.Y + LoginButton.Height + 6;
            PlayButton.TextDisplay.Outline = true;
            PlayButton.AddEventListener(Event.CLICKLEFT, OnPlay);
            PlayButton.AddEventListener(Event.MOUSEOVER, OnPlayButtonOver);
            PlayButton.AddEventListener(Event.MOUSEOUT, OnPlayButtonOut);

            OptionsButton = new TextButton("Options", 30);
            OptionsButton.X = (GameApplication.WIDTH - OptionsButton.Width) / 2;
            OptionsButton.Y = PlayButton.Y + PlayButton.Height + 6;
            OptionsButton.TextDisplay.Outline = true;
            OptionsButton.AddEventListener(Event.MOUSEOVER, OnOptionsButtonOver);
            OptionsButton.AddEventListener(Event.MOUSEOUT, OnOptionsButtonOut);

            ExitButton = new TextButton("Exit", 30);
            ExitButton.X = (GameApplication.WIDTH - ExitButton.Width) / 2;
            ExitButton.Y = OptionsButton.Y + OptionsButton.Height + 6;
            ExitButton.TextDisplay.Outline = true;
            ExitButton.AddEventListener(Event.CLICKLEFT, OnExit);
            ExitButton.AddEventListener(Event.MOUSEOVER, OnExitButtonOver);
            ExitButton.AddEventListener(Event.MOUSEOUT, OnExitButtonOut);

            Background = new FilledRectangle(AssetLoader.LoadAsset<Texture2D>("images/titleScreenBackground"))
            {
                X = 0,
                Y = 0
            };

            Background.AddChild(Title);
            Background.AddChild(RegisterButton);
            Background.AddChild(LoginButton);
            Background.AddChild(PlayButton);
            Background.AddChild(OptionsButton);
            Background.AddChild(ExitButton);
        }

        private void OnClick(object sender, Tuple<string, string> e) => App.Info($"Element '{(string)sender}' dispatch '{e.Item2}' from parent '{e.Item1}'.");

        private void _loginPanel_OnPanelExit() => Background.RemoveChild(MaskBlocker);

        private void _registerPanel_OnPanelExit() => Background.RemoveChild(MaskBlocker);

        private void OnRegisterOver(object sender, EventArgs e) => RegisterButton.TextDisplay.SpriteColor = Color.Yellow;

        private void OnRegisterOut(object sender, EventArgs e) => RegisterButton.TextDisplay.SpriteColor = Color.White;

        private void OnLoginOut(object sender, EventArgs e) => LoginButton.TextDisplay.SpriteColor = Color.White;

        private void OnLoginOver(object sender, EventArgs e) => LoginButton.TextDisplay.SpriteColor = Color.Yellow;

        private void OnLoginPanel(object sender, EventArgs e)
        {
            App.Warn("Login!");

            Background.AddChild(MaskBlocker);
            Background.AddChild(LoginPanel);
        }

        private void OnRegisterPanel(object sender, EventArgs e)
        {
            Background.AddChild(MaskBlocker);
            Background.AddChild(RegisterPanel);
        }

        private void OnPlayButtonOver(object sender, EventArgs e) => PlayButton.TextDisplay.SpriteColor = Color.Yellow;

        private void OnPlayButtonOut(object sender, EventArgs e) => PlayButton.TextDisplay.SpriteColor = Color.White;

        private void OnOptionsButtonOver(object sender, EventArgs e) => OptionsButton.TextDisplay.SpriteColor = Color.Yellow;

        private void OnOptionsButtonOut(object sender, EventArgs e) => OptionsButton.TextDisplay.SpriteColor = Color.White;

        private void OnExitButtonOver(object sender, EventArgs e) => ExitButton.TextDisplay.SpriteColor = Color.Yellow;

        private void OnExitButtonOut(object sender, EventArgs e) => ExitButton.TextDisplay.SpriteColor = Color.White;

        private void OnPlay(object sender, EventArgs e) => ScreenManager.DispatchScreen(new GameScreen());

        private void OnExit(object sender, EventArgs e) => ScreenManager.CloseGame();

        public override void OnScreenCreate()
        {
        }

        public override void OnScreenDispatch()
        {
        }

        public override void Update(GameTime gameTime)
        {
            TitleFlashSpeedR += 1.0f / gameTime.ElapsedGameTime.Milliseconds * 0.5f;

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