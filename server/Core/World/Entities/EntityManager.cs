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
    }
}