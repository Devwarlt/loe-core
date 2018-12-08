using LoESoft.Server.Core.World.Stats;

namespace LoESoft.Server.Core.World.Entities.Player
{
    public partial class Player
    {
        public override string ExportStat()
        {
            Export.AddOrUpdate(StatType.INVENTORY_0, Inventory[0]);
            Export.AddOrUpdate(StatType.INVENTORY_1, Inventory[1]);
            Export.AddOrUpdate(StatType.INVENTORY_2, Inventory[2]);
            Export.AddOrUpdate(StatType.INVENTORY_3, Inventory[3]);
            Export.AddOrUpdate(StatType.INVENTORY_4, Inventory[4]);
            Export.AddOrUpdate(StatType.INVENTORY_5, Inventory[5]);
            Export.AddOrUpdate(StatType.INVENTORY_6, Inventory[6]);
            Export.AddOrUpdate(StatType.INVENTORY_7, Inventory[7]);
            Export.AddOrUpdate(StatType.INVENTORY_8, Inventory[8]);
            Export.AddOrUpdate(StatType.INVENTORY_9, Inventory[9]);
            Export.AddOrUpdate(StatType.INVENTORY_10, Inventory[10]);
            Export.AddOrUpdate(StatType.INVENTORY_11, Inventory[11]);
            Export.AddOrUpdate(StatType.INVENTORY_12, Inventory[12]);
            Export.AddOrUpdate(StatType.INVENTORY_13, Inventory[13]);
            Export.AddOrUpdate(StatType.INVENTORY_14, Inventory[14]);
            Export.AddOrUpdate(StatType.INVENTORY_15, Inventory[15]);
            Export.AddOrUpdate(StatType.INVENTORY_16, Inventory[16]);
            Export.AddOrUpdate(StatType.INVENTORY_17, Inventory[17]);
            Export.AddOrUpdate(StatType.INVENTORY_18, Inventory[18]);
            Export.AddOrUpdate(StatType.INVENTORY_19, Inventory[19]);
            Export.AddOrUpdate(StatType.INVENTORY_20, Inventory[20]);
            Export.AddOrUpdate(StatType.INVENTORY_21, Inventory[21]);
            Export.AddOrUpdate(StatType.INVENTORY_22, Inventory[22]);
            Export.AddOrUpdate(StatType.INVENTORY_23, Inventory[23]);
            Export.AddOrUpdate(StatType.INVENTORY_24, Inventory[24]);
            Export.AddOrUpdate(StatType.INVENTORY_25, Inventory[25]);
            Export.AddOrUpdate(StatType.INVENTORY_26, Inventory[26]);
            Export.AddOrUpdate(StatType.INVENTORY_27, Inventory[27]);
            Export.AddOrUpdate(StatType.INVENTORY_28, Inventory[28]);
            Export.AddOrUpdate(StatType.INVENTORY_29, Inventory[29]);
            Export.AddOrUpdate(StatType.INVENTORY_30, Inventory[30]);
            Export.AddOrUpdate(StatType.INVENTORY_31, Inventory[31]);
            Export.AddOrUpdate(StatType.INVENTORY_32, Inventory[32]);
            Export.AddOrUpdate(StatType.INVENTORY_33, Inventory[33]);
            Export.AddOrUpdate(StatType.INVENTORY_34, Inventory[34]);
            Export.AddOrUpdate(StatType.INVENTORY_35, Inventory[35]);
            Export.AddOrUpdate(StatType.INVENTORY_36, Inventory[36]);

            return base.ExportStat();
        }
    }
}