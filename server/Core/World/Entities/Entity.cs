using System;

namespace LoESoft.Server.Core.World.Entities
{
    public class Entity : IDisposable
    {
        public Entity() { }

        public virtual void Dispose() { }
    }
}
