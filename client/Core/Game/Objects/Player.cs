using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.Game.Animation;
using LoESoft.Client.Core.Networking.Packets.Outgoing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace LoESoft.Client.Core.Game.Objects
{
    public partial class Player : BasicObject
    {
        public Player(GameUser gameuser) : base(Color.White)
        {
            IsMoving = false;
            _animation = new PlayerAnimation();
            GameUser = gameuser;
            DistinationX = (int)X;
            DistinationY = (int)Y;
        }

        public override void Update(GameTime gameTime)
        {
            DetectMovement();
            HandleMovement(1f / gameTime.ElapsedGameTime.Milliseconds);
            _animation.Update(gameTime, this);
        }

        public override void Draw(SpriteBatch spriteBatch) => _animation.Draw(spriteBatch, this);

        #region "Fields"

        protected Dictionary<Keys, Direction> KeysToDirection = new Dictionary<Keys, Direction>()
        {
            { Keys.None, Direction.None },
            { Keys.W, Direction.Up }, { Keys.Up, Direction.Up },
            { Keys.S, Direction.Down }, { Keys.Down, Direction.Down },
            { Keys.A, Direction.Left }, { Keys.Left, Direction.Left },
            { Keys.D, Direction.Right }, { Keys.Right, Direction.Right }
        };

        public int DistinationX { get; set; }
        public int DistinationY { get; set; }
        public GameUser GameUser { get; private set; }
        public Direction CurrentDirection { get; private set; }
        public bool IsMoving { get; private set; }

        private PlayerAnimation _animation;

        #endregion "Fields"

        #region "Move"

        private void SendMovePacket()
        {
            if (IsMoving)
                GameUser.SendPacket(new ClientMove()
                {
                    Direction = (int)CurrentDirection,
                    Player = this
                });
        }

        public void DetectMovement()
        {
            if (Keyboard.GetState().GetPressedKeys().SkipWhile(_ => KeysToDirection.Keys.Contains(_) ? false : true).Count() > 0)
            {
                if (Keyboard.GetState().GetPressedKeys().SkipWhile(_ => KeysToDirection.Keys.Contains(_) ? false : true).Count() > 1)
                    BrmeClient.Warn("WARN! Do not spam input!");

                IsMoving = true;

                CurrentDirection = KeysToDirection[Keyboard.GetState().GetPressedKeys().SkipWhile(_ => KeysToDirection.Keys.Contains(_) ? false : true).First()];

                if (DistinationX == X && DistinationY == Y)
                    SendMovePacket();
            }

            if (Keyboard.GetState().GetPressedKeys().SkipWhile(_ => KeysToDirection.Keys.Contains(_) ? false : true).Count() == 0 && DistinationX == X && DistinationY == Y)
                ResetMovement();
        }

        public void HandleMovement(float dt)
        {
            if (DistinationX != X)
            {
                if (DistinationX > X)
                    X += dt;
                else if (DistinationX < X)
                    X -= dt;
            }

            if (DistinationY != Y)
            {
                if (DistinationY > Y)
                    Y += dt;
                else if (DistinationY < Y)
                    Y -= dt;
            }
        }

        private void ResetMovement() => IsMoving = false;

        #endregion "Move"
    }
}