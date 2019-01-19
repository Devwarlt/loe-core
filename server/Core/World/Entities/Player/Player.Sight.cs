using LoESoft.Server.Utils;
using System.Collections.Generic;

namespace LoESoft.Server.Core.World.Entities.Player
{
    public partial class Player
    {
        public readonly int SightDiameter = 21;
        public readonly int SightRadius = 10;

        public HashSet<Point> GetSightPoints()
        {
            var points = new HashSet<Point>();

            for (var x = 0; x < SightDiameter; x++)
            {
                for (var y = 0; y < SightDiameter; y++)
                {
                    var px = X + (x - SightRadius);
                    var py = Y + (y - SightRadius);

                    if (px >= 0 && px <= WorldMap.WIDTH && py >= 0 && py <= WorldMap.HEIGHT)
                        points.Add(new Point(px, py));
                }
            }

            return points;
        }
    }
}