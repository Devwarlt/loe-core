using LoESoft.Server.Core.World.Stats;

namespace LoESoft.Server.Core.World.Entities.Player
{
    public partial class Player
    {
        public override string ExportStat()
        {
            Export.AddOrUpdate<Item>(StatType.INVENTORY_0, Inventory.Items[0]);
            Export.AddOrUpdate<Item>(StatType.INVENTORY_1, Inventory.Items[1]);
            Export.AddOrUpdate<Item>(StatType.INVENTORY_2, Inventory.Items[2]);
            Export.AddOrUpdate<Item>(StatType.INVENTORY_3, Inventory.Items[3]);
            Export.AddOrUpdate<Item>(StatType.INVENTORY_4, Inventory.Items[4]);
            Export.AddOrUpdate<Item>(StatType.INVENTORY_5, Inventory.Items[5]);
            Export.AddOrUpdate<Item>(StatType.INVENTORY_6, Inventory.Items[6]);
            Export.AddOrUpdate<Item>(StatType.INVENTORY_7, Inventory.Items[7]);
            Export.AddOrUpdate<Item>(StatType.INVENTORY_8, Inventory.Items[8]);
            Export.AddOrUpdate<Item>(StatType.INVENTORY_9, Inventory.Items[9]);
            Export.AddOrUpdate<Item>(StatType.INVENTORY_10, Inventory.Items[10]);
            Export.AddOrUpdate<Item>(StatType.INVENTORY_11, Inventory.Items[11]);
            Export.AddOrUpdate<Item>(StatType.INVENTORY_12, Inventory.Items[12]);
            Export.AddOrUpdate<Item>(StatType.INVENTORY_13, Inventory.Items[13]);
            Export.AddOrUpdate<Item>(StatType.INVENTORY_14, Inventory.Items[14]);
            Export.AddOrUpdate<Item>(StatType.INVENTORY_15, Inventory.Items[15]);
            Export.AddOrUpdate<Item>(StatType.INVENTORY_16, Inventory.Items[16]);
            Export.AddOrUpdate<Item>(StatType.INVENTORY_17, Inventory.Items[17]);
            Export.AddOrUpdate<Item>(StatType.INVENTORY_18, Inventory.Items[18]);
            Export.AddOrUpdate<Item>(StatType.INVENTORY_19, Inventory.Items[19]);
            Export.AddOrUpdate<Item>(StatType.INVENTORY_20, Inventory.Items[20]);
            Export.AddOrUpdate<Item>(StatType.INVENTORY_21, Inventory.Items[21]);
            Export.AddOrUpdate<Item>(StatType.INVENTORY_22, Inventory.Items[22]);
            Export.AddOrUpdate<Item>(StatType.INVENTORY_23, Inventory.Items[23]);
            Export.AddOrUpdate<Item>(StatType.INVENTORY_24, Inventory.Items[24]);
            Export.AddOrUpdate<Item>(StatType.INVENTORY_25, Inventory.Items[25]);
            Export.AddOrUpdate<Item>(StatType.INVENTORY_26, Inventory.Items[26]);
            Export.AddOrUpdate<Item>(StatType.INVENTORY_27, Inventory.Items[27]);
            Export.AddOrUpdate<Item>(StatType.INVENTORY_28, Inventory.Items[28]);
            Export.AddOrUpdate<Item>(StatType.INVENTORY_29, Inventory.Items[29]);
            Export.AddOrUpdate<Item>(StatType.INVENTORY_30, Inventory.Items[30]);
            Export.AddOrUpdate<Item>(StatType.INVENTORY_31, Inventory.Items[31]);
            
            return base.ExportStat();
        }

    }
}
