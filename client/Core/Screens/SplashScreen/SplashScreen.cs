using LoESoft.Client.Assets;
using LoESoft.Client.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LoESoft.Client.Core.Screens
{
    public class SplashScreen : Screen
    {
        private const int DELAY_BETWEEN_SPLASH = 3500;

        private int CurrentTime { get; set; } = DELAY_BETWEEN_SPLASH;
        private bool FadeIn { get; set; }
        private bool FadedOut { get; set; }
        private float TextureToDrawAlpha { get; set; }
        private Texture2D TextureToDraw { get; set; }
        private Queue<Texture2D> TexturesToDisplay { get; set; }

        public override void OnScreenCreate()
        {
            TexturesToDisplay = new Queue<Texture2D>();
            TexturesToDisplay.Enqueue(AssetLoader.LoadAsset<Texture2D>("images/loeLogo"));
        }

        public override void OnScreenDispatch()
        {
        }

        public override void Update(GameTime gameTime)
        {
            if (CurrentTime > 0)
                CurrentTime -= gameTime.ElapsedGameTime.Milliseconds;

            if (CurrentTime <= 0 && FadedOut)
            {
                TextureToDraw = null;

                if (TexturesToDisplay.Count == 0 && GameApplication.Loaded)
                {
                    ScreenManager.DispatchScreen(GameApplication.TitleScreen = new TitleScreen());
                    return;
                }

                CurrentTime = DELAY_BETWEEN_SPLASH;
            }

            if (TextureToDraw == null)
            {
                TextureToDrawAlpha = 0;
                FadedOut = false;
                FadeIn = true;
                TextureToDraw = TexturesToDisplay.Dequeue();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Clear();

            if (TextureToDraw == null)
                return;

            if (FadeIn)
            {
                TextureToDrawAlpha = 1f - ((float) CurrentTime / DELAY_BETWEEN_SPLASH);

                if (FadeIn && TextureToDrawAlpha >= 1)
                    FadeIn = false;
            }
            else
            {
                TextureToDrawAlpha -= 0.02f;

                if (!FadedOut && TextureToDrawAlpha <= 0)
                    FadedOut = true;
            }

            spriteBatch.Begin();
            spriteBatch.Draw(TextureToDraw, Vector2.Zero, Color.White * TextureToDrawAlpha);
            spriteBatch.End();
        }
    }
}