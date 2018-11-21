using LoESoft.Client.Core.Game.Animation;
using LoESoft.Client.Core.Game.PathFinder;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LoESoft.Client.Core.Game.Objects
{
    public class EntityObject : Entity
    {
        private ObjectAnimation Animation;

        private AStar PathFinder;

        private Queue<Point> _astartPath;
        private bool _isPathFinding;

        public EntityObject(int id) : base(id)
        {
            _astartPath = new Queue<Point>();

            Animation = new ObjectAnimation();
            PathFinder = new AStar();
            _isPathFinding = false;
        }

        public void Init()
        {
            Animation.InitOrUpdate(Content);
        }

        public override void HandleMovement(float dt)
        {
            if (_astartPath.Count > 0)
            {
                if (X == DistinationX && Y == DistinationY)
                {
                    var path = _astartPath.Dequeue();

                    DistinationX = path.X;
                    DistinationY = path.Y;
                }
                else
                {
                    base.HandleMovement(dt);
                }
            }
            else
            {
                _isPathFinding = false;
            }
        }

        public override void SetDistination(int x, int y)
        {
            if (!_isPathFinding)
            {
                _isPathFinding = true;

                var nodes = PathFinder.GetPath(new Point((int)X, (int)Y), new Point(x, y)).Result;

                foreach (var i in nodes)
                    _astartPath.Enqueue(i.Point);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Animation.Draw(spriteBatch, this);
        }

        public override void Update(GameTime gameTime)
        {
            Animation.Update(gameTime, this);
            base.Update(gameTime);
        }
    }
}