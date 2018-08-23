using LoESoft.Client.Assets;
using LoESoft.Client.Core.game;
using LoESoft.Client.Drawing.Sprites.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoESoft.Client
{
    public class GameApplication : Game
    {
        public static int WIDTH => 600;
        public static int HEIGHT => 600;

        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;

        public GameApplication()
        {
            _graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferHeight = WIDTH,
                PreferredBackBufferWidth = HEIGHT
            };

            IsMouseVisible = true;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize() { base.Initialize(); }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            AssetLoader.Init(Content);
            AudioManager.Init();
            TextDisplay.LoadSpriteFont(Content);
            ScreenManager.Init();
            ScreenManager.OnGameClose += ExitGame;
        }

        private void ExitGame()
        {
            GameClient._networkHandler.Dispose();

            Exit();
        }

        protected override void UnloadContent() { }

        protected override void Update(GameTime gameTime)
        {
            ScreenManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(125, 0, 0, 1));

            ScreenManager.Draw(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}
