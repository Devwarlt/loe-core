using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LoESoft.Client.Core.Game.Objects
{
    public partial class BasicPlayer : BasicObject
    {

        public BasicPlayer()
            : base()
        {

        }

        public override void Update(GameTime gameTime)
        {
            UpdateMovement(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

    }
    public partial class BasicPlayer : BasicObject
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
        
        public void UpdateMovement(GameTime gameTime)
        {
            previousKeyBoard = newKeyBoard;
            newKeyBoard = Keyboard.GetState();
            var list = previousKeyBoard.GetPressedKeys().Select(_ => (_validKeysToDirection.ContainsKey(_)) ? _ : Keys.None).ToList();

            var pressedKey = (list.Count > 0) ? list[0] : Keys.None;

            var dt = 1.0f / gameTime.ElapsedGameTime.Milliseconds;

            var spd = 1 * dt;

            Move(pressedKey, spd);

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
            Direction direction = GetValidKey(input);

            if (direction == Direction.None)
                return;

            switch (direction) //TODO: Animation Display + Move cooldown
            {
                case Direction.Up: { Y -= spd; return; }
                case Direction.Down: { Y += spd; return; }
                case Direction.Left: { X -= spd; return; }
                case Direction.Right: { X += spd; return; }
                default: { return; }
            }
        }

        private Direction GetValidKey(Keys key)
        {
            if (_validKeysToDirection.ContainsKey(key))
                return _validKeysToDirection[key];
            return Direction.None;
        }
    }
}
