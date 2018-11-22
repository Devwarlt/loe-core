namespace LoESoft.Client.Core.Game.Objects.Stats
{
    public class Stat
    {
        public int StatType { get; set; }
        public object Value { get; set; }
    }

    public class StatType
    {
        public const int HEALTH = 0;
        public const int SIZE = 1;
        public const int INVENTORY = 2;
    }
}