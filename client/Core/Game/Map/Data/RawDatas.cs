namespace LoESoft.Client.Core.Game.Map.Data
{
    public class RawData
    {
        public string[] Data { get; set; }

        public RawData() => Data = new string[] { };
    }

    public class RawMapData : RawData
    {
        public RawMapData()
        {
        }
    }

    public class RawEntityData : RawData
    {
        public RawEntityData()
        {
        }
    }

    public class RawPlayerData : RawData
    {
        public RawPlayerData()
        {
        }
    }
}