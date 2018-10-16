namespace LoESoft.WebServer.Core.Database.Models
{
    public class Account
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Rank { get; set; }
        public string Token { get; set; }
        public string Creation { get; set; }
    }
}