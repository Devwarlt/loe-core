namespace LoESoft.Server.Core.World.Entities.Interfaces
{
    interface IUpdatable
    {
        int UpdateCount { get; set; }

        void OnUpdate();
    }
}
