#define TEMP_DISABLE

using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.Game;
using LoESoft.Client.Core.Game.Objects;
using LoESoft.Client.Core.Networking;
using LoESoft.Client.Core.Networking.Packets.Outgoing;
using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Sprites.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoESoft.Client.Core.Screens
{
    public class GameScreen : Screen
    {
        public static Map PlayerMap { get; set; }

        public Player TempPlayer { get; set; }

        private GameUser _gameUser = GameApplication.GameUser;

        public override void OnScreenCreate()
        {

            TempPlayer = new Player(_gameUser);
            PlayerMap = new Map();

            GameClient.Warn("Sending Load!");
            _gameUser.SendPacket(new Load());
        }

        public override void OnScreenDispatch() => _gameUser.Disconnect();

        public override void Update(GameTime gameTime)
        {
            TempPlayer.Update(gameTime);

            Camera.SetFocus(TempPlayer);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Clear();
            spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: Camera.GetMatrix());
            if (_gameUser.IsConnected)
            {
                PlayerMap.Draw(spriteBatch);
                TempPlayer.Draw(spriteBatch);

                spriteBatch.End();
            } else
            {
                int w = (int)TextDisplay.MeasureString("Unable To Connect The Server!", 30).X;
                var notConnectedText = new TextDisplay(DrawHelper.CenteredPosition(GameApplication.WIDTH,
                    w), 400, "Unable To Connect The Server!", 30);
            }
        }
    }
}
