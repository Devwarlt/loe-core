#define TEMP_DISABLE

using LoESoft.Client.Core.Game;
using LoESoft.Client.Core.Game.Map;
using LoESoft.Client.Core.Game.User;
using LoESoft.Client.Core.Models;
using LoESoft.Client.Core.Networking;
using LoESoft.Client.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LoESoft.Client.Core.Screens
{
    public class GameScreen : Screen
    {
        public GamePlayer Controller { get; set; }

        private GameCamera Camera { get; set; }

        public GameScreen(PlayerInfo info)
        {
            Controller = new GamePlayer(info);
            Camera = new GameCamera();
        }
        
        public override void OnScreenCreate()
        {
            Camera.Update(Controller.Player);
        }

        public override void OnScreenDispatch() => NetworkClient.Dispose();

        public override void Update(GameTime gameTime)
        {
            Controller.Update(gameTime);
            Camera.Update(Controller.Player);
            WorldMap.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            try
            {
                spriteBatch.Clear();
                spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: Camera.GetMatrix());

                WorldMap.Draw(spriteBatch, (int)Controller.Player.X, (int)Controller.Player.Y);
                Controller.Draw(spriteBatch);
            }
            catch (InvalidOperationException) { }

            spriteBatch.End();
        }
    }
}