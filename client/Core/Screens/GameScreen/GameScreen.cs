#define TEMP_DISABLE

using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.Game;
using LoESoft.Client.Core.Game.Map;
using LoESoft.Client.Core.Game.Objects;
using LoESoft.Client.Core.Game.User;
using LoESoft.Client.Core.Networking.Packets.Outgoing;
using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Sprites.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LoESoft.Client.Core.Screens
{
    public class GameScreen : Screen
    {
        public static Map PlayerMap { get; set; }

        public GamePlayer Player { get; set; }

        private GameUser GameUser = GameApplication.GameUser;

        public override void OnScreenCreate()
        {
            Player = new GamePlayer(GameUser);
            PlayerMap = new Map();
            GameUser.SendPacket(new Load());
        }

        public override void OnScreenDispatch() => GameUser.Disconnect();

        public override void Update(GameTime gameTime)
        {
            Player.Update(gameTime);

            Camera.SetFocus(Player.UserPlayer);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            try
            {
                spriteBatch.Clear();
                spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: Camera.GetMatrix());

                if (GameUser.IsConnected)
                {
                    PlayerMap.Draw(spriteBatch);
                    Player.Draw(spriteBatch);
                }
                else
                    new TextDisplay(DrawHelper.CenteredPosition(GameApplication.WIDTH,
                        (int) TextDisplay.MeasureString("Unable To Connect The Server!", 30).X),
                        400, "Unable To Connect The Server!", 30).Draw(spriteBatch);
            }
            catch (InvalidOperationException) { }

            spriteBatch.End();
        }
    }
}