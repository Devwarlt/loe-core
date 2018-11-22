using LoESoft.Client.Core.Game.User.Data;
using LoESoft.Client.Core.Game.User.GUI.UI.Elements;
using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Sprites.Forms;
using Microsoft.Xna.Framework.Graphics;

namespace LoESoft.Client.Core.Game.User.GUI.UI
{
    public class PlayerInfoTable : Panel
    {
        public InventoryView Inventory { get; set; }
        public StatView StatsView { get; set; }

        public PlayerInfoTable()
            : base(DrawHelper.CenteredToScreenWidth(800), DrawHelper.CenteredToScreenHeight(600), "PlayerInfo", 800, 600, new RGBColor(25, 150, 155), 0.5f)
        {
            IsZeroApplicaple = true;

            Inventory = new InventoryView(350, 50);
            StatsView = new StatView(5, 50);

            AddChild(StatsView);
            AddChild(Inventory);
        }

        public void Init(Inventory inventory)
        {
            for (var i = 0; i < inventory.Items.Length; i++)
                Inventory.SetItem(i, inventory.Items[i].Id);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.StartClamp();
            base.Draw(spriteBatch);
            spriteBatch.EndClamp();
        }
    }
}
