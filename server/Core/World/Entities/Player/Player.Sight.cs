using LoESoft.Server.Utils;
using System;
using System.Collections.Generic;

namespace LoESoft.Server.Core.World.Entities.Player
{
    public partial class Player
    {
        public Point[] GetSightPoints(int radius = 5)
        {
            int areaOfSight = (int)(Math.PI * radius * radius + 1);
            var points = new List<Point>();

            for (var x = -areaOfSight; x < areaOfSight; x++)
                for (var y = -areaOfSight; y < areaOfSight; y++)
                {
                    var sx = x * x;
                    var sy = y * y;

                    if (sx + sy <= areaOfSight)
                        points.Add(new Point(x + X, y + Y));
                }

            return points.ToArray();
        }
    }
}