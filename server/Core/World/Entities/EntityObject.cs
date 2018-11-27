using LoESoft.Server.Core.World.Stats;
using LoESoft.Server.Utils;
using System;

namespace LoESoft.Server.Core.World.Entities
{
    //Class to identify non aesthetic entities such as enemies, npc, and players
    public class EntityObject : Entity
    {
        private int _hp;

        public int Health
        {
            get => _hp;
            set => IncrementVar<int>(ref _hp, value);
        }
        
        public Direction Direction { get; set; }

        public EntityObject(WorldManager manager, int id) 
            : base(manager, id)
        {
            Direction = Direction.Up;
            Health = new Random().Next(10, 100);
        }

        public override string ExportStat()
        {
            Export.AddOrUpdate<int>(StatType.HEALTH, Health);

            return base.ExportStat();
        }
    }
}
