using LoESoft.Client.Assets.Xml;
using LoESoft.Client.Core.Game.Animation;
using LoESoft.Client.Core.Game.Objects.Stats;
using LoESoft.Client.Core.Game.User.Data;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LoESoft.Client.Core.Game.Objects
{
    public partial class Player : GameObject
    {
        public Player(int id) : base(id)
        {
            Animation = new PlayerAnimation();

            Inventory = new Inventory();

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

        public override void ChangeStat(int type, object value)
        {
            switch (type)
            {
                case StatType.HEALTH: Health = int.Parse(value.ToString()); break;
                case StatType.SIZE: Size = int.Parse(value.ToString()); break;
                case StatType.INVENTORY:
                    {
                        var inv = JsonConvert.DeserializeObject<Inventory>(value.ToString());
                        Inventory.Init(inv.Items);
                        //HUD.InfoTable.Init(Inventory);
                    }
                    break;
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

        public Inventory Inventory { get; set; }

        public int Health { get; set; }

        private PlayerAnimation Animation;

        #endregion "Fields"
    }
}