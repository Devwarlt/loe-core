using LoESoft.Client.Assets.Xml.Structure;
using LoESoft.Client.Core.Game.Map;
using System;
using System.Collections.Generic;

namespace LoESoft.Client.Core.Game.PathFinder
{
    public class PathNode
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int G { get; set; } //Distance from start node
        public int H { get; set; } //Distance from end node

        public int Cost
        {
            get => G + H;
        }//Total distance

        //Properties
        public bool Blocked { get; set; }

        public bool Checked { get; set; }
            
        public PathNode(XmlContent content, int x , int y)
        {
            if (content is ObjectsContent)
                Blocked = (content as ObjectsContent).Blocked;
            else if (content is TilesContent)
                Blocked = !(content as TilesContent).Walkable;
            else
                Blocked = false; //Unloaded stuff

            X = x;
            Y = y;
        }

        public void SetCost(int sx, int sy, int ex, int ey, int g)
        {
            H = (Math.Abs(X - ex)) + (Math.Abs(Y - ey));
            G = (Math.Abs(X - sx)) + (Math.Abs(Y - sy)) + g;
        }

        public List<PathNode> Neighbors()
        {
            var points = new List<PathNode>();

            if ((X - 1) > 0)
                if (WorldMap.TileMap[(X - 1), Y] != null)
                    points.Add(new PathNode(WorldMap.TileMap[(X - 1), Y].TileProperties, (X - 1), Y));
            if ((X + 1) < WorldMap.MapWidth)
                if (WorldMap.TileMap[(X + 1), Y] != null)
                    points.Add(new PathNode(WorldMap.TileMap[(X + 1), Y].TileProperties, (X + 1), Y));
            if ((Y - 1) > 0)
                if (WorldMap.TileMap[X, (Y - 1)] != null)
                    points.Add(new PathNode(WorldMap.TileMap[X, (Y - 1)].TileProperties, X, (Y - 1)));
            if ((Y + 1) < WorldMap.MapHeight)
                if (WorldMap.TileMap[X, (Y + 1)] != null)
                    points.Add(new PathNode(WorldMap.TileMap[X, (Y + 1)].TileProperties, X, (Y + 1)));

            return points;
        }
    }
}
