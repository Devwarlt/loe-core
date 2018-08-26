using LoESoft.Client.Assets;
using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Events;
using LoESoft.Client.Drawing.Sprites.Forms;
using LoESoft.Client.Drawing.Sprites.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LoESoft.Client.Core.Screens
{
    public class TitleScreen : Screen
    {
        private TextDisplay Title { get; set; }
        private TextButton PlayButton { get; set; }
        private TextButton OptionButton { get; set; }
        private TextButton ExitButton { get; set; }

        private Texture2D BackgroundImage { get; set; }
        private FilledRectangle Background { get; set; }

        public TitleScreen()
        {
            var buttonGap = 6;

            Title = new TextDisplay(0, 0, "LoeSoft", 30, new RGBColor(255, 0, 0));
            Title.X = (GameApplication.WIDTH - Title.Width) / 2;
            Title.Y = Title.Height * 3;
            Title.Outline = true;

            PlayButton = new TextButton("Play", 30);
            PlayButton.X = (GameApplication.WIDTH - PlayButton.Width) / 2;
            PlayButton.Y = ((GameApplication.HEIGHT - PlayButton.Height) / 2);
            PlayButton.TextDisplay.Outline = true;

            OptionButton = new TextButton("Options", 30);
            OptionButton.X = (GameApplication.WIDTH - OptionButton.Width) / 2;
            OptionButton.Y = PlayButton.Y + PlayButton.Height + buttonGap;
            OptionButton.TextDisplay.Outline = true;

            ExitButton = new TextButton("Exit", 30);
            ExitButton.X = (GameApplication.WIDTH - ExitButton.Width) / 2;
            ExitButton.Y = OptionButton.Y + OptionButton.Height + buttonGap;
            ExitButton.TextDisplay.Outline = true;

            PlayButton.AddEventListener(Event.CLICKLEFT, OnPlay);
            ExitButton.AddEventListener(Event.CLICKLEFT, OnExit);

            BackgroundImage = AssetLoader.LoadAsset<Texture2D>("images/exampleTitleBackground");

            Background = new FilledRectangle(BackgroundImage);

            Background.AddChild(Title);
            Background.AddChild(PlayButton);
            Background.AddChild(OptionButton);
            Background.AddChild(ExitButton);
        }

        private void OnPlay(object sender, EventArgs e) => ScreenManager.DispatchScreen(new GameScreen());
        private void OnExit(object sender, EventArgs e) => ScreenManager.CloseGame();

        public override void OnScreenCreate() { }
        public override void OnScreenDispatch() { }

        public override void Update(GameTime gameTime) => Background.Update(gameTime);

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            Background.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
