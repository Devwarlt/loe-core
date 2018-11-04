using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LoESoft.Server.Core.World.Entities.Player
{
    public class Points
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    public partial class Player
    {
        public Points[] GetSightPoints(int radius = 8)
        {
            List<Points> points = new List<Points>();

            for (var x = -radius; x < X + radius; x++)
                for (var y = -radius; y < Y + radius; y++)
                {
                    var sx = x * x;
                    var sy = y * y;
                    var sr = radius * radius;

                    if (sx + sy <= radius)
                        points.Add(new Points() { X = x, Y = y });
                }

            return points.ToArray();
        }
    }
}
