using LoESoft.Client.Assets.Xml;
using LoESoft.Client.Core.Game.Animation;
using LoESoft.Client.Core.Game.Objects.Stats;
using LoESoft.Client.Core.Game.PathFinder;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LoESoft.Client.Core.Game.Objects
{
    public class Entity : GameObject
    {
        private ObjectAnimation Animation;

        private AStar PathFinder;

        private Queue<Point> _astarPath;
        //private bool _isPathFinding;

        public Direction CurrentDirection { get; set; }

        public int Health { get; set; }
        public int MaximumHealth { get; set; }

        public Entity(int id) : base(id)
        {
            CurrentDirection = Direction.Down;
            Animation = new ObjectAnimation();

            _astarPath = new Queue<Point>();
            PathFinder = new AStar();
            //_isPathFinding = false;
        }

        public override void Init()
        {
            Animation.UpdateOrAdd(Content);
            Texture = XmlLibrary.GetSpriteFromContent(Content, 0, 1);
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
            base.SetDistination(x, y);
        }

        public override void ChangeStat(int type, object value)
        {
            switch (type)
            {
                case StatType.HEALTH: Health = int.Parse(value.ToString()); break;
                case StatType.SIZE: Size = int.Parse(value.ToString()); break;
                case StatType.MAXIMUMHP: MaximumHealth = int.Parse(value.ToString()); break;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Animation.Draw(spriteBatch, this);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Animation.Update(gameTime, this);
        }
    }
}