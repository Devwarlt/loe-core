using LoESoft.Server.Core.World.Stats;
using LoESoft.Server.Utils;

namespace LoESoft.Server.Core.World.Entities
{
    //Class to identify non aesthetic entities such as enemies, npc, and players
    public class Entity : GameObject
    {
        private int _hp;

        public int Health
        {
            get => _hp;
            set => IncrementVar<int>(ref _hp, value);
        }
        
        public Direction Direction { get; set; }

        public Entity(WorldManager manager, int id) 
            : base(manager, id)
        {
            IsEntity = true;

            Direction = Direction.Down;

            Health = LoERandom.Next(10, 100);
        }

        public override string ExportStat()
        {
            Export.AddOrUpdate<int>(StatType.HEALTH, Health);

            return base.ExportStat();
        }
    }
}
