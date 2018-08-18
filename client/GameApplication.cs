using LoESoft.Log;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using LoESoft.Client.Assets;
using LoESoft.Client.Core.game;
using LoESoft.Client.Core.networking.gameuser;

namespace LoESoft.Client
{
    public class GameApplication : Game
    {
        public static Info _info => new Info(nameof(GameApplication));
        public static Warn _warn => new Warn(nameof(GameApplication));
        public static Error _error => new Error(nameof(GameApplication));
        public static int WIDTH => 600;
        public static int HEIGHT => 600;

        public GameUser _gameUser { get; set; }

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
            
            AssetReader.Load(Content);

            
            //ScreenManager.Init should be loaded last
            ScreenManager.Init();
        }

        protected override void UnloadContent() { }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            ScreenManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            ScreenManager.Draw(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}
