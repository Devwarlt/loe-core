namespace LoESoft.Server.Utils
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
    }
}