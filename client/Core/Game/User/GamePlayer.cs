using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.Game.Objects;
using LoESoft.Client.Core.Game.User.GUI;
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

        public Player Player { get; private set; }
        //public PlayerHUD HUD { get; private set; }

        public int ObjectId { get; private set; }

        public GamePlayer(GameUser user, int objId, int classType)
        {
            CanMove = true;
            User = user;
            ObjectId = objId;
            Player = new Player(classType);
            Player.ObjectId = ObjectId;
            Player.Init();
        }
        
        public void ImportStat(string export)
        {
            Player.ImportStat(export);
        }

        public bool CanMove { get; set; }

        private void HandlePlayerInput()
        {
            if (Keyboard.GetState().GetPressedKeys().SkipWhile(_ => !Player.KeysToDirection.Keys.Contains(_)).Count() > 0)
            {
                Player.CurrentDirection = Player.KeysToDirection[Keyboard.GetState().GetPressedKeys().SkipWhile(_ => Player.KeysToDirection.Keys.Contains(_) ? false : true).First()];

                if (!Player.IsMoving && CanMove)
                {
                    SendMovePacket();
                    CanMove = false;
                }
            }
        }

        public void SetDistination(int x, int y)
        {
            Player.DistinationX = x;
            Player.DistinationY = y;

            CanMove = true;
        }

        public void Update(GameTime gameTime)
        {
            HandlePlayerInput();

            Player.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Player.Draw(spriteBatch);
        }

        private void SendMovePacket() => User.SendPacket(new ClientMove() { Direction = (int)Player.CurrentDirection });
    }
}