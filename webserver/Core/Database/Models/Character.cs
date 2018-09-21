using System;

namespace LoESoft.WebServer.Core.Database.Models
{
    public class Character
    {
        public int Id { get; set; }
        public int World { get; set; }
        public Account Account { get; set; }
        public string Name { get; set; }
        public int Class { get; set; }
        public int PositionId { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public DateTime Creation { get; set; }
    }
}
