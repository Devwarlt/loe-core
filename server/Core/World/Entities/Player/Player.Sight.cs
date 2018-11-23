using LoESoft.Server.Utils;
using System.Collections.Generic;

namespace LoESoft.Server.Core.World.Entities.Player
{
    public partial class Player
    {
        public Point[] GetSightPoints(int radius = 30)
        {
            var points = new List<Point>();

            for (var x = -radius; x < radius; x++)
                for (var y = -radius; y < radius; y++)
                {
                    var sx = x * x;
                    var sy = y * y;

                    if (sx + sy <= radius)
                        points.Add(new Point(x + X, y + Y));
                }

            return points.ToArray();
        }
    }
}