using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoESoft.Client.Core.Game.PathFinder
{
    public class AStar
    {
        public async Task<HashSet<PathNode>> GetPath(Point start, Point end)
        {
            var startNode = new PathNode(start.X, start.Y, null, end);

            var path = new HashSet<PathNode>();

            await Task.Factory.StartNew(() =>
            {
                var closedList = new HashSet<PathNode>();
                var openList = new HashSet<PathNode>();
                var curNode = startNode;

                openList.Add(curNode);

                do
                {
                    closedList.Add(curNode);
                    openList.Remove(curNode);

                    foreach (var i in curNode.Neighbors().OrderBy(_ => _.F))
                    {
                        if (i.Point == end)
                        {
                            closedList.Add(i);
                            goto AssignPath;
                        }

                        if (!openList.Contains(i) && !closedList.Contains(i))
                            openList.Add(i);
                    }

                    curNode = openList.OrderBy(_ => _.F).OrderBy(_ => _.H).FirstOrDefault();

                    if (curNode == null)
                    {
                        App.Warn("No path found!");
                        return;
                    }
                } while (!(openList.ToList().Exists(_ => _.Point == end)));

            AssignPath:

                var endNode = closedList.Where(_ => _.Point == end).FirstOrDefault();
                var curPathNode = endNode;

                while (curPathNode != startNode)
                {
                    path.Add(curPathNode);

                    curPathNode = curPathNode.Parent;
                }
            });

            return path.Reverse().ToHashSet();
        }
    }
}