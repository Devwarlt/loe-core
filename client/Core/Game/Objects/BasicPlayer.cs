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
            Up = 0, Down = 1, Left = 2, Right = 3, None = 4
        }

        public Direction CurrentDirection = Direction.Up;

        Dictionary<Keys, Direction> _validKeysToDirection = new Dictionary<Keys, Direction>()
            {
                { Keys.W, Direction.Up },
                { Keys.S, Direction.Down },
                { Keys.A, Direction.Left },
                { Keys.D, Direction.Right }
            };

        KeyboardState previousKeyBoard;
        KeyboardState newKeyBoard;

        //float speed = 0.5f;
        //float timer = 0f;

        public void UpdateMovement(float dt)
        {
            newKeyBoard = Keyboard.GetState();

            var keysPressed = previousKeyBoard.GetPressedKeys().Select(_ => _validKeysToDirection.ContainsKey(_) ? _ : Keys.None).ToList();
            var pressedKey = (keysPressed.Count > 0) ? keysPressed[0] : Keys.None;

            var spd = 1 * dt;
            Move(pressedKey, spd);

            previousKeyBoard = newKeyBoard;

            //if (newKeyBoard.IsKeyDown(pressedKey)) //toggle press
            //{
            //    timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            //    if (timer >= speed)
            //        Move(pressedKey);
            //} else if (newKeyBoard.IsKeyUp(pressedKey)) //singular press
            //{
            //    Move(pressedKey);
            //    timer = 0f;
            //}
        }

        protected void Move(Keys input, float spd)
        {
            var direction = GetValidKey(input);

            if (direction == Direction.None)
                return;

            //TODO: Animation Display + Move cooldown
            switch (direction)
            {
                case Direction.Up: Y -= spd; break;
                case Direction.Down: Y += spd; break;
                case Direction.Left: X -= spd; break;
                case Direction.Right: X += spd; break;
                default: break;
            }
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
