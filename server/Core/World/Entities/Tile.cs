namespace LoESoft.Server.Core.World.Entities
{
    public class Tile : Entity
    {
        public bool Walkable { get; set; }

        public Tile(WorldManager manager, int id)
        : base(manager, id)
        {
            Walkable = true;
        }
    }
}