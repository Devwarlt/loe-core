using LoESoft.Client.Assets;
using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.Screens;
using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Events;
using LoESoft.Client.Drawing.Sprites.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoESoft.Client
{
    public class GameApplication : Game
    {
        public static int WIDTH { get; set; } = 1200;
        public static int HEIGHT { get; set; } = 900;

        public static GameScreen GameScreen { get; set; }
        public static CharacterScreen CharacterScreen { get; set; }

        protected GraphicsDeviceManager GraphicsDeviceManager { get; set; }
        protected SpriteBatch SpriteBatch { get; set; }

        public GameUser GameUser { get; set; }

        public GameApplication(GameUser gameUser)
        {
            GameUser = gameUser;

            GraphicsDeviceManager = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = WIDTH,
                PreferredBackBufferHeight = HEIGHT
            };

            Window.AllowUserResizing = false;
            Window.ClientSizeChanged += Window_ClientSizeChanged;
            
            IsMouseVisible = true;
            Content.RootDirectory = "Content";
        }

        private void Window_ClientSizeChanged(object sender, System.EventArgs e)
        {
        }

        protected override void Initialize()
        {
            base.Initialize();

            App.DiscordRichPresence.State = "World: Chicago";
            App.DiscordRichPresence.Details = "Main Menu";

            App.UpdateRPC();

            //No point in making it a variable as it'll only be used in initial launch
            ScreenManager.DispatchScreen(new SplashScreen(GameUser));

            App.Info("Game Client is initializing... OK!");
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            AssetLoader.Init(Content);
            DrawHelper.Setup(GraphicsDevice, SpriteBatch);
            TextDisplay.LoadSpriteFont(Content);

            ScreenManager.CloseGame += () =>
            {
                App.DscordClient.ClearPresence();
                App.DscordClient.Dispose();
                Exit();
            };
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            EventsHandler.Update();
            EventsManager.Update();
            ScreenManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            SpriteBatch.ClearColor(125, 0, 0, 1);

            ScreenManager.Draw(SpriteBatch);

            base.Draw(gameTime);
        }
    }
}