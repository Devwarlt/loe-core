#define TEMP_DISABLE

using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.Game;
using LoESoft.Client.Core.Game.Objects;
using LoESoft.Client.Core.Networking;
using LoESoft.Client.Core.Networking.Packets.Outgoing;
using LoESoft.Client.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Threading;

namespace LoESoft.Client.Core.Screens
{
    public class GameScreen : Screen
    {
        public static GameUser GameUser { get; set; }
        public static Map PlayerMap { get; set; }
        
        public Player TempPlayer { get; set; }

        public override void OnScreenCreate()
        {
            GameUser = new GameUser(new Server("127.0.0.1", 7171));
            GameUser.Connect();

            TempPlayer = new Player(GameUser);
            PlayerMap = new Map();

            GameClient.Warn("Sending Load!");
            GameUser.SendPacket(new Load());
        }

        public override void OnScreenDispatch() => GameUser.Disconnect();

        public override void Update(GameTime gameTime)
        {
            TempPlayer.Update(gameTime);

            Camera.SetFocus(TempPlayer);

            if (!GameUser.IsConnected)
                ScreenManager.DispatchScreen(new TitleScreen());
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Clear();

            spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: Camera.GetMatrix());

            PlayerMap.Draw(spriteBatch);

            TempPlayer.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
