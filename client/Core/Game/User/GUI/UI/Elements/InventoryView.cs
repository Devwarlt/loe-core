using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.Game.User.Data;
using LoESoft.Client.Core.Networking.Packets.Outgoing;
using LoESoft.Client.Drawing.Sprites.Forms;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace LoESoft.Client.Core.Game.User.GUI.UI.Elements
{
    public class InventoryView : FilledRectangle
    {
        public Dictionary<int, ItemCell> Items { get; set; }

        protected GameUser User;
        
        public InventoryView(GameUser user, int x, int y)
            : base(x, y, 445, 225, new Drawing.RGBColor(255, 255, 255))
        {
            Items = new Dictionary<int, ItemCell>();
            User = user;
        }

        public void ReloadInventory(Item[] inv)
        {
            int x = 5;
            int y = 5;

            for (var i = 0; i < inv.Count(); i++)
            {
                if (!Items.ContainsKey(i))
                {
                    Items.Add(i, new ItemCell(inv[i].Id, i, x, y));
                    Items[i].OnDropped += OnInventorySwap;

                    x += 55;

                    if (x > 440)
                    {
                        x = 5;
                        y += 55;
                    }

                    AddChild(Items[i]);
                }
                else
                {
                    Items[i].Reload(inv[i].Id);
                }
            }
        }

        public void OnInventorySwap()
        {
            var target = Items.Values.Where(_ => _.Selected).FirstOrDefault();

            if (target != null)
                User.SendPacket(new InventorySwap()
                {
                    ParentItemIndex = ItemCell.DraggedIndex,
                    TargetItemIndex = target.ItemIndex
                });
            else
                Items[ItemCell.DraggedIndex].Reload(Items[ItemCell.DraggedIndex].Id);

            ItemCell.DraggedIndex = -1;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}