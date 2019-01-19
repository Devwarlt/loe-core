using LoESoft.Client.Core.Networking;

namespace LoESoft.Client.Core.Game.Map.Data
{
    public class TileData
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Id { get; set; }

        public void Read(NetworkReader reader)
        {
            X = reader.ReadInt32();
            Y = reader.ReadInt32();
            Id = reader.ReadInt32();
        }
    }
}