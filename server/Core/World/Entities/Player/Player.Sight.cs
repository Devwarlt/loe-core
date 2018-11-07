﻿using System.Collections.Generic;

namespace LoESoft.Server.Core.World.Entities.Player
{
    public class Points
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Points(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    public partial class Player
    {
        public Points[] GetSightPoints(int radius = 30)
        {
            var points = new List<Points>();
            
            for (var x = -radius; x < radius; x++)
                for (var y = -radius; y < radius; y++)
                {
                    var sx = x * x;
                    var sy = y * y;

                    if (sx + sy <= radius)
                        points.Add(new Points(x + X, y + Y));
                }

            return points.ToArray();
        }
    }
}
