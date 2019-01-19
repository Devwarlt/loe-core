using System;

namespace LoESoft.Server.Utils
{
    public struct WorldTime
    {
        public int TickCount { get; set; }
        public double TotalElapsedMs { get; set; }
    }
    public enum Direction
    {
        Up = 0,
        Down = 1,
        Left = 2,
        Right = 3
    }
    public static class LoERandom
    {
        static Random rand = new Random();

        public static int Next(int min, int max) => rand.Next(min, max);
    }
    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}