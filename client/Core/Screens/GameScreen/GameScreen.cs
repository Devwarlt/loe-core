#define TEMP_DISABLE

using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.Game;
using LoESoft.Client.Core.Game.Objects;
using LoESoft.Client.Core.Networking;
using LoESoft.Client.Core.Networking.Packets.Outgoing;
using LoESoft.Client.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace LoESoft.Client.Core.Screens
{
    public class GameScreen : Screen
    {
        public static GameUser GameUser { get; set; }

        public Tile[,] Tiles { get; set; }

        public Player TempPlayer { get; set; }
        public override void OnScreenCreate()
        {
            GameUser = new GameUser(new Server("127.0.0.1", 7171));
            GameUser.Connect();
            var random = new Random();
            Tiles = new Tile[160, 90];

            for (var x = 0; x < 160; x++)
                for (var y = 0; y < 90; y++)
                    Tiles[x, y] = new Tile(x, y, x % 5);

            TempPlayer = new Player();
        }

        public override void OnScreenDispatch()
        {
            GameUser.Disconnect();
        }

        public override void Update(GameTime gameTime)
        {
            var dt = 1.0f / gameTime.ElapsedGameTime.Milliseconds;

            var spd = 1 * dt;

            GameUser.SendPacket(new MovePacket(1100));

            TempPlayer.Update(gameTime);
            Camera.SetFocus(TempPlayer);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Clear();

            spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: Camera.GetMatrix());

            var dx = 160 / 15;
            var dy = 90 / 15;
            for (var x = -dx; x <= dx; x++)
                for (var y = -dy; y <= dy; y++)
                {
                    var tx = (int)(TempPlayer.X + x);
                    var ty = (int)(TempPlayer.Y + y);

                    if (tx < 0 || ty < 0 || tx >= 160 || ty >= 90)
                        continue;

                    Tiles[tx, ty].Draw(spriteBatch);
                }

            TempPlayer.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
