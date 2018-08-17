using LoESoft.Client.gameuser;
using LoESoft.Client.Drawing.Events;
using LoESoft.Client.Drawing.Sprites;
using LoESoft.Log;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

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
        Sprite _testSprite;
        Sprite _testSprite1;

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

            _testSprite = new Sprite(10, 10, 100, 100);
            _testSprite1 = new Sprite(10, 10, 100, 100);

            _testSprite1.AddEventListener(Event.CLICKLEFT, Click1);
            _testSprite.AddEventListener(Event.CLICKLEFT, Click);

            _testSprite.AddChild(_testSprite1);
        }
        private void Click(object o, EventArgs e)
        {
            Console.WriteLine("Clicked");
        }

        private void Click1(object o, EventArgs e)
        {
            Console.WriteLine("Clicked1");
            _info.Write("Dispatching 'PING' packet to the server!");
        }

        protected override void UnloadContent() { }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _testSprite.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _testSprite.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
