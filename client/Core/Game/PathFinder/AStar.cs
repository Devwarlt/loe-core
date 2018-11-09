using LoESoft.Client.Core.Game.Map;
using System.Collections.Generic;
using System.Linq;

namespace LoESoft.Client.Core.Game.PathFinder
{
    public class AStar
    {
        private PathNode _startNode;
        private PathNode _endNode;

        public void CreateOrUpdate(Points start, Points end)
        {
            _startNode = new PathNode(WorldMap.TileMap[start.X, start.Y].TileProperties, start.X, start.Y);
            _startNode.SetCost(_startNode.X, _startNode.Y, _endNode.X, _endNode.Y, 0);
            _endNode = new PathNode(WorldMap.TileMap[end.X, end.Y].TileProperties, start.X, start.Y);
            _endNode.SetCost(_startNode.X, _startNode.Y, _endNode.X, _endNode.Y, 0);
        }

        private List<Points> GeneratePath()
        {
            var checkedList = new List<int>();
            var closedList = new List<PathNode>();
            var path = new List<Points>();

            var currentNode = _startNode;

            Loop();

            void Loop()
            {
                closedList.Add(currentNode);
                path.Add(new Points() { X = currentNode.X, Y = currentNode.Y });

                var neighbor = currentNode.Neighbors();

                foreach (var i in neighbor)
                    i.SetCost(_startNode.X, _startNode.Y, _endNode.X, _endNode.Y, 0);

                try
                {
                    currentNode = neighbor.OrderBy(_ => _.H).Select(e =>
                    {
                        if (!e.Checked)
                            return e;
                        e.Checked = true;
                        return null;
                    }).Where(_ => _ != null).FirstOrDefault();
                }
                catch
                {
                    currentNode = null;
                }

                if (!closedList.Exists(_ => _.H == _endNode.H) && currentNode != null)
                {
                    Loop();
                    App.Warn("Looping!");
                }

                App.Warn("Path Found!");
            };

            return path;
        }

        public List<Points> GetShortestRoute() => GeneratePath();
    }
}