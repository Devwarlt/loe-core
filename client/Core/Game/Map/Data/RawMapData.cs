namespace LoESoft.Client.Core.Game
{
    public class RawMapData
    {
        public string[,] Tiles;

        public RawMapData() => Tiles = new string[16, 16];
    }
}