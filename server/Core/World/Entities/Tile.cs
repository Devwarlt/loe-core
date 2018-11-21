using LoESoft.Server.Core.World.Entities.Interfaces;

namespace LoESoft.Server.Core.World.Entities
{
    public class Tile : IUpdatable
    {
        public int UpdateCount { get; set; }

        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public bool Walkable { get; set; }

        public Tile(WorldManager manager, int id)
        {
            Walkable = true;
            Id = id;
        }

        public void OnUpdate()
        {
            UpdateCount = 0;
        }
    }
}