using LoESoft.Client.Core.Game.Animation;
using LoESoft.Client.Core.Game.PathFinder;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Concurrent;

namespace LoESoft.Client.Core.Game.Objects
{
    public class EntityObject : Entity
    {
        private ObjectAnimation Animation;

        private AStar PathFinder;

        public EntityObject(int id) : base(id)
        {
            Animation = new ObjectAnimation();
            PathFinder = new AStar();
            path = new ConcurrentQueue<Points>();
        }

        public void Init()
        {
            Animation.InitOrUpdate(Content);
        }

        private ConcurrentQueue<Points> path;
        //public void SetNewDistination(int x, int y, int uid)
        //{
        //    lastPoint = new Points() { X = (int)X, Y = (int)Y };

        //    var start = new Points() { X = (int)X, Y = (int)Y };
        //    var end = new Points() { X = x, Y = y };

        //    PathFinder.CreateOrUpdate(start, end);

        //    foreach (var i in PathFinder.GetShortestRoute())
        //    {
        //        path.Enqueue(i);
        //        App.Warn($"{i.X} {i.Y} {uid}");
        //    }
        //}

        //Points lastPoint;
        public override void HandleMovement(float dt)
        {
            //if (path.Count > 0 && lastPoint.X == X && lastPoint.Y == Y)
            //{
            //    if (path.TryDequeue(out var point))
            //    {
            //        DistinationX = point.X;
            //        DistinationY = point.Y;

            //        lastPoint = point;
            //    }
            //}

            base.HandleMovement(dt);
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