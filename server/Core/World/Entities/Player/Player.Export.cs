using LoESoft.Server.Core.World.Entities.Player.Attribute;
using LoESoft.Server.Core.World.Stats;

namespace LoESoft.Server.Core.World.Entities.Player
{
    public partial class Player
    {
        public override string ExportStat()
        {
            Export.AddOrUpdate<Inventory>(StatType.INVENTORY, Inventory);

            return base.ExportStat();
        }
    }
}