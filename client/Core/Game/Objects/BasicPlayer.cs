using System.Collections.Generic;
using System.Linq;
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

        KeyboardState previousKeyBoard;
        KeyboardState newKeyBoard;

        public Player()
        {

        }

        public void UpdateMovement(float dt)
        {
            newKeyBoard = Keyboard.GetState();

            var keysPressed = previousKeyBoard.GetPressedKeys().Select(_ => _validKeysToDirection.ContainsKey(_) ? _ : Keys.None).ToList();
            var pressedKey = (keysPressed.Count > 0) ? keysPressed[0] : Keys.None;

            var spd = 1 * dt;
            Move(pressedKey, spd);

            previousKeyBoard = newKeyBoard;
        }

        protected void Move(Keys input, float spd)
        {
            var direction = GetValidKey(input);

            if (direction == Direction.None)
                return;

            //TODO: Animation Display + Move cooldown
            switch (direction)
            {
                case Direction.Up:
                    Y -= spd;
                    break;
                case Direction.Down:
                    Y += spd;
                    break;
                case Direction.Left:
                    X -= spd;
                    break;
                case Direction.Right:
                    X += spd;
                    break;
                default:
                    break;
            }
            CurrentDirection = direction;
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
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
