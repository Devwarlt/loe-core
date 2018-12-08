using LoESoft.Client.Assets;
using LoESoft.Client.Assets.Xml;
using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.Game.User.Data;
using LoESoft.Client.Core.Networking.Packets.Outgoing;
using LoESoft.Client.Drawing.Sprites;
using LoESoft.Client.Drawing.Sprites.Forms;
using System.Collections.Generic;
using System.Linq;

namespace LoESoft.Client.Core.Game.User.GUI.UI.Elements
{
    public class InventoryView : Sprite
    {
        public class CharacterView : Sprite
        {
            public Sprite CharacterSprite { get; private set; }

            public CharacterView(int x, int y, int id)
                : base(x, y, 150, 200, AssetLibrary.Images["characterDisplayRect"])
            {
                var content = XmlLibrary.ObjectsXml[id];
                CharacterSprite = new Sprite(0, 25, 150, 150, XmlLibrary.GetSpriteFromContent(content, 0, 1));

                AddChild(CharacterSprite);
            }
        }
        public Dictionary<int, ItemCell> InventoryItems { get; set; }
        
        protected GameUser User;

        protected CharacterView PlayerSprite;
        
        public InventoryView(GameUser user, int x, int y)
            : base(x, y, 400, 200)
        {
            InventoryItems = new Dictionary<int, ItemCell>();
            User = user;

            Init();
        }

        private void Init()
        {
            InventoryItems.Add(0, new ItemCell(-1, 0, 25, -200));
            AddChild(InventoryItems[0]);
            InventoryItems.Add(1, new ItemCell(-1, 1, 25, -145));
            AddChild(InventoryItems[1]);
            InventoryItems.Add(2, new ItemCell(-1, 2, 25, -90));
            AddChild(InventoryItems[2]);
            InventoryItems.Add(3, new ItemCell(-1, 3, 325, -200));
            AddChild(InventoryItems[3]);
            InventoryItems.Add(4, new ItemCell(-1, 4, 325, -145));
            AddChild(InventoryItems[4]);

            int x = 0;
            int y = 10;

            for (var i = 5; i < 37; i++)
            {
                if (!InventoryItems.ContainsKey(i))
                {
                    InventoryItems.Add(i, new ItemCell(-1, i, x, y));
                    InventoryItems[i].OnDropped += OnInventorySwap;

                    x += 50;

                    if (x >= 400)
                    {
                        x = 0;
                        y += 50;
                    }

                    AddChild(InventoryItems[i]);
                }
            }
        }

        public void LoadPlayerSprite(GamePlayer player)
        {
            if (!Contains(PlayerSprite))
            {
                PlayerSprite = new CharacterView(130, -215, player.Player.Id);

                AddChild(PlayerSprite);
                return;
            }

            PlayerSprite.CharacterSprite.SpriteTexture = XmlLibrary.GetSpriteFromContent(player.Player.Content, 0, 1);
        }

        public void ReloadInventory(Item[] inv)
        {
            InventoryItems[0].Reload(inv[0].Id);
            InventoryItems[1].Reload(inv[1].Id);
            InventoryItems[2].Reload(inv[2].Id); 
            InventoryItems[3].Reload(inv[3].Id);
            InventoryItems[4].Reload(inv[4].Id);

            for (var i = 5; i < inv.Count(); i++)
                InventoryItems[i].Reload(inv[i].Id);
        }

        public void OnInventorySwap()
        {
            var target = InventoryItems.Values.Where(_ => _.Selected).FirstOrDefault();

            if (target != null)
                User.SendPacket(new InventorySwap()
                {
                    ParentItemIndex = ItemCell.DraggedIndex,
                    TargetItemIndex = target.ItemIndex
                });
            else
                InventoryItems[ItemCell.DraggedIndex].Reload(InventoryItems[ItemCell.DraggedIndex].Id);

            ItemCell.DraggedIndex = -1;
        }
    }
}