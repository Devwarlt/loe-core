using LoESoft.Server.Utils;
using System.Collections.Generic;

namespace LoESoft.Server.Core.World.Entities.Player
{
    public partial class Player
    {
        public HashSet<Point> GetSightPoints(int bound = 10)
        {
            var points = new HashSet<Point>();

            for (var x = -bound; x < bound; x++)
                for (var y = -bound; y < bound; y++)
                {
                    var px = X + x;
                    var py = Y + y;

                    if (px >= 0 && px <= WorldMap.WIDTH && py >= 0 && py <= WorldMap.HEIGHT)
                        points.Add(new Point(px, py));
                }

            return points;
        }
    }
}