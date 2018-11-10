#define TEMP_DISABLE

using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.Game;
using LoESoft.Client.Core.Game.Map;
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

        private GameUser GameUser { get; set; }

        public GameScreen(GameUser gameUser) => GameUser = gameUser;

        public override void OnScreenCreate()
        {
            Controller = new GamePlayer(GameUser);
        }

        public override void OnScreenDispatch() => GameUser.Disconnect();

        public override void Update(GameTime gameTime)
        {
            WorldMap.Update(gameTime);
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
                    WorldMap.Draw(spriteBatch);
                    Controller.Draw(spriteBatch);
                }
            }
            catch (InvalidOperationException) { }

            spriteBatch.End();
        }
    }
}