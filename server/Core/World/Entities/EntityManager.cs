namespace LoESoft.Server.Core.World.Entities
{
    public static class EntityManager
    {
        public static int CurrentId { get; set; } = 0;

        public static int GetNextId()
        {
            CurrentId++;

            return CurrentId;
        }

        public static GameObject CreateObject(WorldManager manager, int x, int y, int id) => new GameObject(manager, id)
        {
            X = x,
            Y = y
        };

        public static Entity CreateEntity(WorldManager manager, int x, int y, int id) => new Entity(manager, id)
        {
            X = x,
            Y = y
        };

        public static Tile CreateTile(WorldManager manager, int x, int y, int id) => new Tile(manager, id)
        {
            X = x,
            Y = y
        };
    }
}