using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.Game.Objects;
using LoESoft.Client.Core.Networking.Packets.Outgoing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;

namespace LoESoft.Client.Core.Game.User
{
    public class GamePlayer
    {
        public GameUser User { get; private set; }

        public Player UserPlayer { get; private set; }

        public GamePlayer(GameUser user)
        {
            UserPlayer = new Player();
        }

        public void Update(GameTime gameTime)
        {
            HandlePlayerInput();

            UserPlayer.Update(gameTime);
        }

        private void HandlePlayerInput()
        {
            if (Keyboard.GetState().GetPressedKeys().SkipWhile(_ => Player.KeysToDirection.Keys.Contains(_) ? false : true).Count() > 0)
            {
                UserPlayer.CurrentDirection = Player.KeysToDirection[Keyboard.GetState().GetPressedKeys().SkipWhile(_ => Player.KeysToDirection.Keys.Contains(_) ? false : true).First()];

                if (UserPlayer.DistinationX == UserPlayer.X && UserPlayer.DistinationY == UserPlayer.Y)
                    SendMovePacket();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            UserPlayer.Draw(spriteBatch);
        }

        private void SendMovePacket()
            =>
            User.SendPacket(new ClientMove()
            {
                Direction = (int)UserPlayer.CurrentDirection,
                Player = UserPlayer
            });

    }
}
