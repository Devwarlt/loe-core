#define TEMP_DISABLE

using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.Game;
using LoESoft.Client.Core.Game.Objects;
using LoESoft.Client.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace LoESoft.Client.Core.Screens
{
    public class GameScreen : Screen
    {
        public GameUser GameUser { get; set; }

        public List<Tile> Tiles { get; set; }

        public BasicObject BasicObject { get; set; }
        public override void OnScreenCreate()
        {
#if !TEMP_DISABLE
            GameUser = new GameUser(new Server("127.0.0.1", 7171));
            GameUser.Connect();
#endif
            var random = new Random();
            Tiles = new List<Tile>();
            for (var i = 0; i < 160; i++)
                for (var j = 0; j < 90; j++)
                    Tiles.Add(new Tile(i, j, i % 5));
            BasicObject = new BasicObject();
        }

        public override void OnScreenDispatch()
        {
#if !TEMP_DISABLE
            GameUser.Disconnect();
#endif
        }

        private float z;
        public override void Update(GameTime gameTime)
        {
            var dt = 1.0f / gameTime.ElapsedGameTime.Milliseconds;

            var spd = 1 * dt;

            var keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.W))
                BasicObject.Y -= spd;
            if (keyState.IsKeyDown(Keys.A))
                BasicObject.X -= spd;
            if (keyState.IsKeyDown(Keys.S))
                BasicObject.Y += spd;
            if (keyState.IsKeyDown(Keys.D))
                BasicObject.X += spd;
            Camera.SetFocus(BasicObject);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Clear();

            spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: Camera.GetMatrix());
            for (var i = 0; i < Tiles.Count; i++)
                Tiles[i].Draw(spriteBatch);
            BasicObject.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
