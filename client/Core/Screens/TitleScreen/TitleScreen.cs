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

            PlayButton = new TextButton("Play", 30);
            PlayButton.X = (GameApplication.WIDTH - PlayButton.Width) / 2;
            PlayButton.Y = (GameApplication.HEIGHT - PlayButton.Height) / 2;
            PlayButton.TextDisplay.Outline = true;

            OptionsButton = new TextButton("Options", 30);
            OptionsButton.X = (GameApplication.WIDTH - OptionsButton.Width) / 2;
            OptionsButton.Y = PlayButton.Y + PlayButton.Height + buttonGap;
            OptionsButton.TextDisplay.Outline = true;

            ExitButton = new TextButton("Exit", 30);
            ExitButton.X = (GameApplication.WIDTH - ExitButton.Width) / 2;
            ExitButton.Y = OptionsButton.Y + OptionsButton.Height + buttonGap;
            ExitButton.TextDisplay.Outline = true;

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

            Background.AddChild(Title);
            Background.AddChild(PlayButton);
            Background.AddChild(OptionsButton);
            Background.AddChild(ExitButton);
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
