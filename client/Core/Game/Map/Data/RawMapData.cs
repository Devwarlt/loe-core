namespace LoESoft.Client.Core.Game
{
    public class RawMapData
    {
        public string[,] Tiles;

        public RawMapData()
        {
            Tiles = new string[16, 16];
        }
    }
    public class RawEntityData
    {
        public string[] Entity;

        public RawEntityData()
        {
            Entity = new string[] { };
        }
    }
    public class RawPlayerData
    {
        public string[] Player;

        public RawPlayerData()
        {
            Player = new string[] { };
        }
    }
}
