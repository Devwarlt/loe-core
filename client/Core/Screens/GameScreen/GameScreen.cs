#define TEMP_DISABLE

using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.Game;
using LoESoft.Client.Core.Game.Objects;
using LoESoft.Client.Core.Networking.Packets.Outgoing;
using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Events;
using LoESoft.Client.Drawing.Sprites;
using LoESoft.Client.Drawing.Sprites.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace LoESoft.Client.Core.Screens
{
    public class GameScreen : Screen
    {
        public static Map PlayerMap { get; set; }

        public Player TempPlayer { get; set; }

        private GameUser _gameUser = GameApplication.GameUser;

        private EventsHandler _eventsHandler;
        private Sprite _mouseSprite;

        public override void OnScreenCreate()
        {
            _eventsHandler = new EventsHandler();
            var mouseStat = Mouse.GetState();
            _mouseSprite = new Sprite(mouseStat.X, mouseStat.Y, 5, 5);
            TempPlayer = new Player(_gameUser);

            PlayerMap = new Map();

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
            try
            {
                spriteBatch.Clear();
                spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: Camera.GetMatrix());

                if (_gameUser.IsConnected)
                {
                    PlayerMap.Draw(spriteBatch);
                    TempPlayer.Draw(spriteBatch);

                    spriteBatch.End();
                }
                else
                    new TextDisplay(DrawHelper.CenteredPosition(GameApplication.WIDTH,
                        (int)TextDisplay.MeasureString("Unable To Connect The Server!", 30).X),
                        400, "Unable To Connect The Server!", 30).Draw(spriteBatch);
            }
            catch (InvalidOperationException) { }
        }
    }
}
