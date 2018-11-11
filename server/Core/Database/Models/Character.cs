namespace LoESoft.Server.Core.Database.Models
{
    public class Character
    {
        public long Id { get; set; }
        public int World { get; set; }
        public int Class { get; set; }
        public Position Position { get; set; }
        public string Creation { get; set; }
        public long AccountId { get; set; }
    }
}