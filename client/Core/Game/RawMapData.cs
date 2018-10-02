namespace LoESoft.Client.Core.Game
{
    public class RawMapData
    {
        public string[,] Tiles { get; set; }
        public string[] Entitys { get; set; }
        public string[] Players { get; set; }

        public RawMapData()
        {
            Tiles = new string[16, 16];
            Entitys = new string[1024];
            Players = new string[120];
        }
    }
}
