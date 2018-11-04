using LoESoft.Client.Core.Game.Animation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LoESoft.Client.Core.Game.Objects
{
    public partial class Player : Entity
    {
        public Player() : base(5)
        {
            Animation = new PlayerAnimation();

            KeysToDirection = new Dictionary<Keys, Direction>()
            {
                { Keys.None, Direction.None },
                { Keys.W, Direction.Up }, { Keys.Up, Direction.Up },
                { Keys.S, Direction.Down }, { Keys.Down, Direction.Down },
                { Keys.A, Direction.Left }, { Keys.Left, Direction.Left },
                { Keys.D, Direction.Right }, { Keys.Right, Direction.Right }
            };

            DistinationX = (int) X;
            DistinationY = (int) Y;
        }

        public override void Update(GameTime gameTime)
        {
            Animation.Update(gameTime, this);
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch) => Animation.Draw(spriteBatch, this);

        #region "Fields"

        public Dictionary<Keys, Direction> KeysToDirection { get; private set; }
        
        public Direction CurrentDirection { get; set; }
        
        private PlayerAnimation Animation;

        #endregion "Fields"
    }
}