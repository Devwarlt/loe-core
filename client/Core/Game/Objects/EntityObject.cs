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

        private Queue<Point> _astarPath;
        private bool _isPathFinding;

        public Direction CurrentDirection { get; set; }

        public EntityObject(int id) : base(id)
        {
            CurrentDirection = Direction.Down;

            _astarPath = new Queue<Point>();

            Animation = new ObjectAnimation();
            PathFinder = new AStar();
            _isPathFinding = false;
        }

        public void Init()
        {
            Animation.UpdateOrAdd(Content);
        }

        public override void HandleMovement(float dt)
        {
            //if (_astartPath.Count > 0)
            //{
            //    //if (X == DistinationX && Y == DistinationY)
            //    //{
            //    //    var path = _astartPath.Dequeue();

            //    //    DistinationX = path.X;
            //    //    DistinationY = path.Y;
            //    //}
            //    //else
            //    //{
            //    //    base.HandleMovement(dt);
            //    //}
            //}

            //foreach(var i in _astarPath)
            //{
            //    DistinationX = i.X;
            //    DistinationY = i.Y;
            //    App.Warn($"{_astarPath.Count}");
            //}

            if (DistinationY != Y)
            {
                if (DistinationY > Y)
                {
                    Y += dt;
                    CurrentDirection = Direction.Down;
                }
                else if (DistinationY < Y)
                {
                    Y -= dt;
                    CurrentDirection = Direction.Up;
                }
            }
            else if (DistinationX != X)
            {
                if (DistinationX > X)
                {
                    X += dt;
                    CurrentDirection = Direction.Right;
                }
                else if (DistinationX < X)
                {
                    X -= dt;
                    CurrentDirection = Direction.Left;
                }
            }
        }

        public override void SetDistination(int x, int y)
        {
            //var nodes = PathFinder.GetPath(new Point((int)X, (int)Y), new Point(x, y)).Result;

            //foreach (var i in nodes)
            //    _astarPath.Enqueue(i.Point);
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