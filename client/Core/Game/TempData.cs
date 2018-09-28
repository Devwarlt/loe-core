namespace LoESoft.Client.Core.Game
{
    public class TempData
    {
        public string[,] Tiles { get; set; }

        public TempData()
        {
            Tiles = new string[16, 16]; //temporary
        }
    }
}
