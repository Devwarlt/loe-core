﻿namespace LoESoft.Server.Utils
{
    public class WorldTime
    {
        public int TickCount { get; set; }
        public int TotalElapsedMs { get; set; }
    }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            var compareTo = (Point)obj;
            return X == compareTo.X && Y == compareTo.Y;
        }

        public override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }
    }
}