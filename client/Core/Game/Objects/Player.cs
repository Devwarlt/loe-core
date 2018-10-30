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
        public Player() : base(Color.White)
        {
            Animation = new PlayerAnimation();
            DistinationX = (int) X;
            DistinationY = (int) Y;
        }

        public override void Update(GameTime gameTime)
        {
            HandleMovement(1f / gameTime.ElapsedGameTime.Milliseconds);
            Animation.Update(gameTime, this);
        }

        public override void Draw(SpriteBatch spriteBatch) => Animation.Draw(spriteBatch, this);

        #region "Fields"

        public static Dictionary<Keys, Direction> KeysToDirection = new Dictionary<Keys, Direction>()
        {
            { Keys.None, Direction.None },
            { Keys.W, Direction.Up }, { Keys.Up, Direction.Up },
            { Keys.S, Direction.Down }, { Keys.Down, Direction.Down },
            { Keys.A, Direction.Left }, { Keys.Left, Direction.Left },
            { Keys.D, Direction.Right }, { Keys.Right, Direction.Right }
        };

        public int DistinationX { get; set; }
        public int DistinationY { get; set; }

        public Direction CurrentDirection { get; set; }

        public bool IsMoving
        {
            get { return (X != DistinationX && Y != DistinationY); }
        }

        private PlayerAnimation Animation;

        #endregion "Fields"

        #region "Move"
        
        public void SetDistination(int x, int y)
        {
            DistinationX = x;
            DistinationY = y;
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

        #endregion "Move"
    }
}