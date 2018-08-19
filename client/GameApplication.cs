using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using LoESoft.Client.Assets;
using LoESoft.Client.Core.game;
using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Sprites.Text;

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

            DrawingSettings.Load(Content);
            AssetReader.Load(Content);
            XmlReader.Load(Content);
            TextDisplay.LoadSpriteFont(Content);
            ScreenManager.Init();
        }

        protected override void UnloadContent() { }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                ExitGame();

            ScreenManager.Update(gameTime);

            base.Update(gameTime);
        }

        private void ExitGame()
        {
            GameClient._networkHandler.Dispose();

            Exit();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            ScreenManager.Draw(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}
