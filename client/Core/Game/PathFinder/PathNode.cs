using LoESoft.Client.Core.Game.Map;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace LoESoft.Client.Core.Game.PathFinder
{
    public class PathNode
    {
        public int F; //Total Cost
        public int H; //Heuristic
        public int G; //Cost

        public Point Point;

        public PathNode Parent { get; set; }

        public Point End;

        public PathNode(int x, int y, PathNode parent, Point endPoint)
        {
            Point = new Point(x, y);
            Parent = parent;
            End = endPoint;

            G = (Parent != null) ? Parent.G + 1 : 0;
            H = (endPoint != null) ? H = Math.Abs(x - endPoint.X) + Math.Abs(y - endPoint.Y) : 0;
            F = G + H;
        }

        public List<PathNode> Neighbors()
        {
            var neighbor = new List<PathNode>();

            neighbor.Add(WorldMap.TileMap.ContainsKey(new Point(Point.X, Point.Y + 1)) ?
                new PathNode(Point.X, Point.Y + 1, this, End) : null);
            neighbor.Add(WorldMap.TileMap.ContainsKey(new Point(Point.X, Point.Y + 1)) ?
                new PathNode(Point.X, Point.Y - 1, this, End) : null);
            neighbor.Add(WorldMap.TileMap.ContainsKey(new Point(Point.X, Point.Y + 1)) ?
                new PathNode(Point.X + 1, Point.Y, this, End) : null);
            neighbor.Add(WorldMap.TileMap.ContainsKey(new Point(Point.X, Point.Y + 1)) ?
                new PathNode(Point.X - 1, Point.Y, this, End) : null);

            neighbor.RemoveAll(_ => _ == null);

            return neighbor;
        }
    }
}