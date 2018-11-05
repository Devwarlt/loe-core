#define TEMP_DISABLE

using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.Game;
using LoESoft.Client.Core.Game.Map;
using LoESoft.Client.Core.Game.Objects;
using LoESoft.Client.Core.Game.User;
using LoESoft.Client.Core.Networking.Packets.Outgoing;
using LoESoft.Client.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LoESoft.Client.Core.Screens
{
    public class GameScreen : Screen
    {
        public GamePlayer Controller { get; set; }

        private GameUser GameUser = GameApplication.GameUser;

        public override void OnScreenCreate()
        {
            Controller = new GamePlayer(GameUser);
            GameUser.SendPacket(new Load());
        }

        public override void OnScreenDispatch() => GameUser.Disconnect();

        public override void Update(GameTime gameTime)
        {
            Map.Update(gameTime);
            Controller.Update(gameTime);

            Camera.SetFocus(Controller.Player);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            try
            {
                spriteBatch.Clear();
                spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: Camera.GetMatrix());

                if (GameUser.IsConnected)
                {
                    Map.Draw(spriteBatch);
                    Controller.Draw(spriteBatch);
                }
            }
            catch (InvalidOperationException) { }

            spriteBatch.End();
        }
    }
}