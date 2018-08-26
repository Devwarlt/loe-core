using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.Networking;
using LoESoft.Client.Core.Utils;
using LoESoft.Client.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoESoft.Client.Core.Screens
{
    public class GameScreen : Screen
    {
        public GameUser GameUser { get; set; }

        public override void OnScreenCreate()
        {
            GameUser = new GameUser(new Server("127.0.0.1", 7171));
            GameUser.Connect();
        }

        public override void OnScreenDispatch()
        {
            GameUser.Disconnect();
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
