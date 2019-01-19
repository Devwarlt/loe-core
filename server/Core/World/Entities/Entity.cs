using LoESoft.Server.Core.Networking.Data;
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
            set => IncrementVar(ref _hp, value);
        }

        private int _maxHp;
        public int MaximumHealth
        {
            get => _maxHp;
            set => IncrementVar(ref _maxHp, value);
        }
        
        public Direction Direction { get; set; }

        public Entity(WorldManager manager, int id) 
            : base(manager, id)
        {
            IsEntity = true;

            MaximumHealth = 100;
            Health = MaximumHealth;

            Direction = Direction.Down;
        }

        public void Damage(int amount)
        {
            if (Health - amount > 0)
                Health -= amount;
            else
            {
                Health = 0;
                Death();
            }
        }

        public void Death() => Dispose();

        public override Stat[] ExportStat()
        {
            Export.AddOrUpdate(StatType.HEALTH, Health);
            Export.AddOrUpdate(StatType.MAXIMUMHP, MaximumHealth);

            return base.ExportStat();
        }
    }
}
