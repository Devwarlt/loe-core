using LoESoft.Client.Core.Networking;
using LoESoft.Client.Core.Utils;
using LoESoft.Client.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoESoft.Client.Core.Screens
{
    public class GameScreen : Screen
    {
        public NetworkManager NetworkManager { get; set; }

        public override void OnScreenCreate()
        {
            GameClient.Info("Loading Network Manager");

            NetworkManager = new NetworkManager();
            NetworkManager.Start();

            GameClient.Info("Network Manager Loaded!");
        }

        public override void OnScreenDispatch()
        {
            NetworkManager?.Dispose();
        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.ClearColor(Color.Orange);
        }
    }
}
