namespace LoESoft.Server.Core.Database.Models
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Type { get; set; }

        public override string ToString() => $"X: {X} / Y: {Y} / Type: {Type}";
    }
}