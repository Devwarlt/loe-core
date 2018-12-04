using LoESoft.Client.Assets.Xml;
using LoESoft.Client.Core.Game.Animation;
using LoESoft.Client.Core.Game.Objects.Stats;
using LoESoft.Client.Core.Game.User.Data;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LoESoft.Client.Core.Game.Objects
{
    public partial class Player : GameObject
    {
        public Player(int id) : base(id)
        {
            Animation = new PlayerAnimation();

            Inventory = new Item[32];

            KeysToDirection = new Dictionary<Keys, Direction>()
            {
                { Keys.W, Direction.Up }, { Keys.Up, Direction.Up },
                { Keys.S, Direction.Down }, { Keys.Down, Direction.Down },
                { Keys.A, Direction.Left }, { Keys.Left, Direction.Left },
                { Keys.D, Direction.Right }, { Keys.Right, Direction.Right }
            };

            DistinationX = (int)X;
            DistinationY = (int)Y;
        }

        public override void Init()
        {
            Animation.UpdateOrAdd(Content);
            Texture = XmlLibrary.GetSpriteFromContent(Content, 0, 1);
        }

        public void Override(int objId, int id)
        {
            if (objId != ObjectId)
                ObjectId = objId;
            if (Id != id)
            {
                Id = id;
                Content = XmlLibrary.ObjectsXml[id];

                Init();
            }
        }

        public override void ChangeStat(int type, object value)
        {
            switch (type)
            {
                case StatType.HEALTH: Health = int.Parse(value.ToString()); break;
                case StatType.SIZE: Size = int.Parse(value.ToString()); break;
                case StatType.INVENTORY_0: Inventory[0] = Item.Deserailize(value.ToString()); break;
                case StatType.INVENTORY_1: Inventory[1] = Item.Deserailize(value.ToString()); break;
                case StatType.INVENTORY_2: Inventory[2] = Item.Deserailize(value.ToString()); break;
                case StatType.INVENTORY_3: Inventory[3] = Item.Deserailize(value.ToString()); break;
                case StatType.INVENTORY_4: Inventory[4] = Item.Deserailize(value.ToString()); break;
                case StatType.INVENTORY_5: Inventory[5] = Item.Deserailize(value.ToString()); break;
                case StatType.INVENTORY_6: Inventory[6] = Item.Deserailize(value.ToString()); break;
                case StatType.INVENTORY_7: Inventory[7] = Item.Deserailize(value.ToString()); break;
                case StatType.INVENTORY_8: Inventory[8] = Item.Deserailize(value.ToString()); break;
                case StatType.INVENTORY_9: Inventory[9] = Item.Deserailize(value.ToString()); break;
                case StatType.INVENTORY_10: Inventory[10] = Item.Deserailize(value.ToString()); break;
                case StatType.INVENTORY_11: Inventory[11] = Item.Deserailize(value.ToString()); break;
                case StatType.INVENTORY_12: Inventory[12] = Item.Deserailize(value.ToString()); break;
                case StatType.INVENTORY_13: Inventory[13] = Item.Deserailize(value.ToString()); break;
                case StatType.INVENTORY_14: Inventory[14] = Item.Deserailize(value.ToString()); break;
                case StatType.INVENTORY_15: Inventory[15] = Item.Deserailize(value.ToString()); break;
                case StatType.INVENTORY_16: Inventory[16] = Item.Deserailize(value.ToString()); break;
                case StatType.INVENTORY_17: Inventory[17] = Item.Deserailize(value.ToString()); break;
                case StatType.INVENTORY_18: Inventory[18] = Item.Deserailize(value.ToString()); break;
                case StatType.INVENTORY_19: Inventory[19] = Item.Deserailize(value.ToString()); break;
                case StatType.INVENTORY_20: Inventory[20] = Item.Deserailize(value.ToString()); break;
                case StatType.INVENTORY_21: Inventory[21] = Item.Deserailize(value.ToString()); break;
                case StatType.INVENTORY_22: Inventory[22] = Item.Deserailize(value.ToString()); break;
                case StatType.INVENTORY_23: Inventory[23] = Item.Deserailize(value.ToString()); break;
                case StatType.INVENTORY_24: Inventory[24] = Item.Deserailize(value.ToString()); break;
                case StatType.INVENTORY_25: Inventory[25] = Item.Deserailize(value.ToString()); break;
                case StatType.INVENTORY_26: Inventory[26] = Item.Deserailize(value.ToString()); break;
                case StatType.INVENTORY_27: Inventory[27] = Item.Deserailize(value.ToString()); break;
                case StatType.INVENTORY_28: Inventory[28] = Item.Deserailize(value.ToString()); break;
                case StatType.INVENTORY_29: Inventory[29] = Item.Deserailize(value.ToString()); break;
                case StatType.INVENTORY_30: Inventory[30] = Item.Deserailize(value.ToString()); break;
                case StatType.INVENTORY_31: Inventory[31] = Item.Deserailize(value.ToString()); break;
            }
        }

        public override void Update(GameTime gameTime)
        {
            Animation.Update(gameTime, this);
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch) => Animation.Draw(spriteBatch, this);

        #region "Fields"

        public Dictionary<Keys, Direction> KeysToDirection { get; private set; }

        public Direction CurrentDirection { get; set; }

        public Item[] Inventory { get; set; }

        public int Health { get; set; }

        private PlayerAnimation Animation;

        #endregion "Fields"
    }
}