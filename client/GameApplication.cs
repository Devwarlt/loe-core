using LoESoft.Client.Drawing.Events;
using LoESoft.Client.Drawing.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace LoESoft.Client
{
    public class GameApplication : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Sprite testSprite;
        Sprite testSprite1;

        public GameApplication()
        {
            graphics = new GraphicsDeviceManager(this);

            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 600;
            IsMouseVisible = true;

            Content.RootDirectory = "Content";
        }

        protected override void Initialize() { base.Initialize(); }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            testSprite = new Sprite(10, 10, 100, 100);
            testSprite1 = new Sprite(10, 10, 100, 100);

            testSprite1.AddEventListener(Event.CLICKLEFT, Click1);
            testSprite.AddEventListener(Event.CLICKLEFT, Click);

            testSprite.AddChild(testSprite1);
        }

        private void Click(object o, EventArgs e)
        {
            Console.WriteLine("Clicked");
        }

        private void Click1(object o, EventArgs e)
        {
            Console.WriteLine("Clicked1");
        }

        protected override void UnloadContent() { }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            testSprite.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            testSprite.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
