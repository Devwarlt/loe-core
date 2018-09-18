using System.Collections.Generic;
using System.Linq;
using LoESoft.Client.Core.Game.Animation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LoESoft.Client.Core.Game.Objects
{
    public class Player : BasicObject
    {
        public enum Direction : int
        {
            None = 0, Up = 1, Down = 2, Left = 3, Right = 4
        }

        Dictionary<Keys, Direction> _validKeysToDirection = new Dictionary<Keys, Direction>()
            {
                { Keys.W, Direction.Up },
                { Keys.S, Direction.Down },
                { Keys.A, Direction.Left },
                { Keys.D, Direction.Right }
            };

        public Direction CurrentDirection = Direction.Up;
        public bool IsMoving { get; set; }

        PlayerAnimation _animation;
        KeyboardState previousKeyBoard;
        KeyboardState newKeyBoard;

        public Player()
        {
            _animation = new PlayerAnimation();
        }

        public void UpdateMovement(float dt)
        {
            newKeyBoard = Keyboard.GetState();

            var keysPressed = previousKeyBoard.GetPressedKeys().Select(_
                => _validKeysToDirection.ContainsKey(_) ? _ : Keys.None).ToList();

            var spd = 1 * dt;

            if (keysPressed.Count <= 0)
                IsMoving = false;
            
            foreach (var i in keysPressed)
            {
                var direction = GetValidKey(i);

                if (direction == Direction.Up)
                    Y -= spd;
                if (direction == Direction.Down)
                    Y += spd;
                if (direction == Direction.Left)
                    X -= spd;
                if (direction == Direction.Right)
                    X += spd;
                IsMoving = true;
                CurrentDirection = direction;
            }

            previousKeyBoard = newKeyBoard;
        }

        private Direction GetValidKey(Keys key)
        {
            if (_validKeysToDirection.ContainsKey(key))
                return _validKeysToDirection[key];
            return Direction.None;
        }

        public override void Update(GameTime gameTime)
        {
            var dt = 1.0f / gameTime.ElapsedGameTime.Milliseconds;

            UpdateMovement(dt);
            _animation.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            _animation.Draw(spriteBatch, this);
        }
    }
}
