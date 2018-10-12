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

        protected Dictionary<Keys, Direction> KeysToDirection = new Dictionary<Keys, Direction>()
        {
            { Keys.None, Direction.None },
            { Keys.W, Direction.Up }, { Keys.Up, Direction.Up },
            { Keys.S, Direction.Down }, { Keys.Down, Direction.Down },
            { Keys.A, Direction.Left }, { Keys.Left, Direction.Left },
            { Keys.D, Direction.Right }, { Keys.Right, Direction.Right }
        };

        protected int DistinationX;
        protected int DistinationY;

        public GameUser GameUser { get; private set; }
        public Direction CurrentDirection { get; private set; }
        public bool IsMoving { get; private set; }

        PlayerAnimation _animation;
        Timer sendTimer = new Timer(250);

        public Player(GameUser gameuser) : base(Color.White)
        {
            IsMoving = false;
            _animation = new PlayerAnimation();
            GameUser = gameuser;
            sendTimer.Start();
            sendTimer.Elapsed += SendTimer_Elapsed;
        }

        public override void Update(GameTime gameTime)
        {
            var dt = 1f / gameTime.ElapsedGameTime.Milliseconds; //MOVEMENT SPEED
            DetectMovement();
            UpdateMovement(dt);
            _animation.Update(gameTime, this);
        }

        public override void Draw(SpriteBatch spriteBatch) => _animation.Draw(spriteBatch, this);

        public void UpdateMovement(float dt)
        {
            if (X != DistinationX || Y != DistinationY)
            {
                if (X != DistinationX)
                {
                    if (X > DistinationX) X -= dt;
                    if (X < DistinationX) X += dt;
                }
                if (Y != DistinationY)
                {
                    if (Y > DistinationY) Y -= dt;
                    if (Y < DistinationY) Y += dt;
                }
            }
        }

        private void SendTimer_Elapsed(object sender, ElapsedEventArgs e) => SendMovePacket();

        private void SendMovePacket()
        {
            GameUser.SendPacket(new Move()
            {
                X = (int)X,
                Y = (int)Y
            });
        }

        public void DetectMovement()
        {
            var pressedKeys = Keyboard.GetState().GetPressedKeys().SkipWhile(_ => (KeysToDirection.Keys.Contains(_)) ? false : true);

            foreach (var i in pressedKeys)
            {
                IsMoving = true;

                CurrentDirection = KeysToDirection[i];

                if (DistinationX == X && DistinationY == Y)
                    Move(CurrentDirection);
            }

            if (pressedKeys.Count() == 0 && DistinationX == X && DistinationY == Y)
                ResetMovement();
        }

        private void Move(Direction direction)
        {
            DistinationX = (int)X;
            DistinationY = (int)Y;

            switch (direction)
            {
                case Direction.Up: DistinationY -= 1; break;
                case Direction.Down: DistinationY += 1; break;
                case Direction.Left: DistinationX -= 1; break;
                case Direction.Right: DistinationX += 1; break;
            }
        }

        private void ResetMovement() => IsMoving = false;
    }
}
