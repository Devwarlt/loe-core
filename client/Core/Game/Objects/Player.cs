using System.Collections.Generic;
using System.Linq;
using LoESoft.Client.Core.Game.Animation;
using LoESoft.Client.Core.Networking.Packets.Outgoing;
using LoESoft.Client.Core.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LoESoft.Client.Core.Game.Objects
{
    public partial class Player : BasicObject
    {
        public Player()
        {
            IsMoving = false;
            _animation = new PlayerAnimation();
        }
        
        public override void Update(GameTime gameTime)
        {
            var dt = 1f / gameTime.ElapsedGameTime.Milliseconds; //MOVEMENT SPEED
            DetectMovement();
            UpdateMovement(dt);
            _animation.Update(gameTime, this);
        }

        public override void Draw(SpriteBatch spriteBatch) => _animation.Draw(spriteBatch, this);
    }
    public partial class Player
    {
        public enum Direction
        {
            None = 0,
            Up = 1,
            Down = 2,
            Left = 3,
            Right = 4
        }

        public Direction CurrentDirection { get; private set; }
        
        PlayerAnimation _animation;
        KeyboardState _curKeyBoard;

        public bool IsMoving { get; private set; }
        
        public void UpdateMovement(float dt)
        {
            if (X != DistinationX)
            {
                if (X > DistinationX)
                    X -= dt;
                else if (X < DistinationX)
                    X += dt;
            }
            if (Y != DistinationY)
            {
                if (Y > DistinationY)
                    Y -= dt;
                else if (Y < DistinationY)
                    Y += dt;
            }
        }

        public void DetectMovement()
        {
            _curKeyBoard = Keyboard.GetState();

            var pressedKeys = _curKeyBoard.GetPressedKeys().SkipWhile(_ =>
            (KeysToDirection.Keys.Contains(_)) ? false : true);

            foreach(var i in pressedKeys)
            {
                IsMoving = true;

                CurrentDirection = KeysToDirection[i];

                if (DistinationX == X && DistinationY == Y)
                    Move(CurrentDirection);
            }

            if (pressedKeys.Count() == 0 && DistinationX == X 
                && DistinationY == Y)
                ResetMovement();
        }

        protected int DistinationX;
        protected int DistinationY;

        private void Move(Direction direction)
        {
            DistinationX = (int)X;
            DistinationY = (int)Y;

            switch(direction)
            {
                case Direction.Up: DistinationY -= 1; break;
                case Direction.Down: DistinationY += 1; break;
                case Direction.Left: DistinationX -= 1; break;
                case Direction.Right: DistinationX += 1; break;
            }
        }

        private void ResetMovement()
        {
            IsMoving = false;
        }

        protected Dictionary<Keys, Direction> KeysToDirection = new Dictionary<Keys, Direction>()
        {
            { Keys.None, Direction.None },
            { Keys.W, Direction.Up }, { Keys.Up, Direction.Up },
            { Keys.S, Direction.Down }, { Keys.Down, Direction.Down },
            { Keys.A, Direction.Left }, { Keys.Left, Direction.Left },
            { Keys.D, Direction.Right }, { Keys.Right, Direction.Right }
        };
    }
}
