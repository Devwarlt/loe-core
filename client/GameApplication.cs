using LoESoft.Client.Assets;
using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.Screens;
using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Events;
using LoESoft.Client.Drawing.Sprites.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Threading;
using static LoESoft.Client.Core.Networking.Server;

namespace LoESoft.Client
{
    public class GameApplication : Game
    {
        public static int WIDTH => 800;
        public static int HEIGHT => 600;
        public static TitleScreen TitleScreen { get; set; }
        public static SplashScreen SplashScreen { get; set; }

        protected GraphicsDeviceManager GraphicsDeviceManager { get; set; }
        protected SpriteBatch SpriteBatch { get; set; }

        public static GameUser GameUser { get; private set; }

        public static bool Loaded = false;

        public GameApplication()
        {
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
            
            ScreenManager.DispatchScreen(SplashScreen = new SplashScreen());

            GameUser = new GameUser(GetServers[ServerName.LOCAL]);
            GameUser.Connect();

            GameClient._discordPresence.State = "World: Chicago";
            GameClient._discordPresence.Details = "Main Menu";

            GameClient.UpdateRPC();
            
            Loaded = true;
            GameClient.Info("Game Client is initializing... OK!");
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            AssetLoader.Init(Content);
            AssetLibrary.Init();
            XmlLibrary.Init();
            AudioManager.Init();
            DrawHelper.Setup(GraphicsDevice, SpriteBatch);
            TextDisplay.LoadSpriteFont(Content);

            //AudioManager.SetActiveMusic("titleScreenMusic");

            ScreenManager.OnGameClose += () =>
            {
                GameClient._discordClient.ClearPresence();
                GameClient._discordClient.Dispose();

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