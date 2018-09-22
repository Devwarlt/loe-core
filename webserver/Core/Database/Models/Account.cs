using System;

namespace LoESoft.WebServer.Core.Database.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Rank { get; set; }
        public string Token { get; set; }
        public DateTime Creation { get; set; }
    }
}
