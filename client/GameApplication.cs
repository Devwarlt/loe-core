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
        public static int WIDTH => 800;
        public static int HEIGHT => 600;
        public static SplashScreen SplashScreen { get; set; }
        public static GameScreen GameScreen { get; set; }

        protected GraphicsDeviceManager GraphicsDeviceManager { get; set; }
        protected SpriteBatch SpriteBatch { get; set; }

        public static bool Loaded = false;

        public GameUser GameUser { get; set; }

        public GameApplication(GameUser gameUser)
        {
            GameUser = gameUser;

            GraphicsDeviceManager = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = WIDTH,
                PreferredBackBufferHeight = HEIGHT
            };

            IsMouseVisible = true;

            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();

            App.DiscordRichPresence.State = "World: Chicago";
            App.DiscordRichPresence.Details = "Main Menu";

            App.UpdateRPC();

            Loaded = true;

            App.Info("Game Client is initializing... OK!");
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            AssetLoader.Init(Content);
            DrawHelper.Setup(GraphicsDevice, SpriteBatch);
            TextDisplay.LoadSpriteFont(Content);

            ScreenManager.DispatchScreen(SplashScreen = new SplashScreen(GameUser));

            AssetLibrary.Init();
            XmlLibrary.Init();
            AudioManager.Init();

            //AudioManager.SetActiveMusic("titleScreenMusic");

            ScreenManager.OnGameClose += () =>
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