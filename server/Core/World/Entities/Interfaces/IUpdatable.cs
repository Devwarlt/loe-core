namespace LoESoft.Server.Core.World.Entities.Interfaces
{
    internal interface IUpdatable
    {
        int UpdateCount { get; set; }

        void OnUpdate();
    }
}