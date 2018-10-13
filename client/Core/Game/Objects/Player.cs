using System.Collections.Generic;
using System.Linq;
using System.Timers;
using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.Game.Animation;
using LoESoft.Client.Core.Networking.Packets.Outgoing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LoESoft.Client.Core.Game.Objects
{
    public class Player : BasicObject
    {
        public enum Direction
        {
            None = 0,
            Up = 1,
            Down = 2,
            Left = 3,
            Right = 4
        }

        #region FIELDS

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

        PlayerAnimation _animation;
        #endregion

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
            var dt = 1f / gameTime.ElapsedGameTime.Milliseconds; //MOVEMENT SPEED
            DetectMovement();
            HandleMovement(dt);
            _animation.Update(gameTime, this);
        }

        public override void Draw(SpriteBatch spriteBatch) => _animation.Draw(spriteBatch, this);

        #region MOVE
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
            var pressedKeys = Keyboard.GetState().GetPressedKeys().SkipWhile(_ => 
            (KeysToDirection.Keys.Contains(_)) ? false : true);

            if (pressedKeys.Count() > 0)
            {
                if (pressedKeys.Count() > 1)
                    GameClient.Warn("WARN! Do not spam input!");

                IsMoving = true;

                CurrentDirection = KeysToDirection[pressedKeys.First()];

                GameClient.Warn(CurrentDirection.ToString());

                if (DistinationX == X && DistinationY == Y)
                    SendMovePacket();
            }

            if (pressedKeys.Count() == 0 && DistinationX == X && DistinationY == Y)
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
        #endregion
    }
}
