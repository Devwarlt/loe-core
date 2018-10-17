namespace LoESoft.WebServer.Core.Database.Models
{
    public class Character
    {
        public long Id { get; set; }
        public int World { get; set; }
        public Account Account { get; set; }
        public string Name { get; set; }
        public int Class { get; set; }
        public string Position { get; set; } // TODO.
        public string Creation { get; set; }
    }
}