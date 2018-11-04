
using LoESoft.Server.Core.World.Map.Data;
using System.Collections.Generic;

namespace LoESoft.Server.Core.World.Entities
{
    public class Tile
    {
        public int Id { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public bool Walkable { get; set; }

        public Tile(int id)
        {
            Id = id;
            Walkable = true;
        }

        public TileData GetData => new TileData() { X = X, Y = Y, Id = Id };
    }
}
