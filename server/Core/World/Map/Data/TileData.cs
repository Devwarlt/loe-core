using LoESoft.Server.Core.World.Entities;

namespace LoESoft.Server.Core.World.Map.Data
{
    public class TileData
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Id { get; set; }

        public static TileData GetData(Tile tile) => new TileData()
        {
            X = tile.X,
            Y = tile.Y,
            Id = tile.Id
        };
    }
}