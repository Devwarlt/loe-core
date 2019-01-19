namespace LoESoft.Server.Core.Database.Models
{
    public class Account
    {
        public long Id { get; set; }
        public int CurrentCharacterId { get; set; }
        public string Gmail { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Rank { get; set; }
        public string Token { get; set; }
        public string Creation { get; set; }
    }
}