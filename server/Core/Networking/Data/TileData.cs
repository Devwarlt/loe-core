using LoESoft.Server.Core.World.Entities;

namespace LoESoft.Server.Core.Networking.Data
{
    public class TileData
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Id { get; set; }
        
        public void Write(NetworkWriter writer)
        {
            writer.Write(X);
            writer.Write(Y);
            writer.Write(Id);
        }

        public static TileData GetData(Tile tile) => new TileData()
        {
            X = tile.X,
            Y = tile.Y,
            Id = tile.Id
        };
    }
}