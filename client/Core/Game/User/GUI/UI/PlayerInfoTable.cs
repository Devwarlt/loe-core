using LoESoft.Client.Core.Game.User.Data;
using LoESoft.Client.Core.Game.User.GUI.UI.Elements;
using LoESoft.Client.Core.Game.User.GUI.UI.Elements.Icon;
using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Sprites.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoESoft.Client.Core.Game.User.GUI.UI
{
    public class PlayerInfoTable : Panel
    {
        public InfoIcon Icons { get; set; }
        public InventoryView Inventory { get; set; }
        public StatView StatsView { get; set; }

        public PlayerInfoTable()
            : base(DrawHelper.CenteredToScreenWidth(600), DrawHelper.CenteredToScreenHeight(600), "Guest", 600, 600)
        {
            IsZeroApplicaple = true;

            Icons = new InfoIcon(265, 45, onInventory, onStats);

            Inventory = new InventoryView(100, 325);
            StatsView = new StatView(50, 125);

            AddChild(Inventory);
            AddChild(Icons);

            Title.SpriteColor = new Color(249, 214, 214);
            Title.Y = 13;
        }

        private void onInventory()
        {
            if (Contains(StatsView))
                RemoveChild(StatsView);

            if (!Contains(Inventory))
                AddChild(Inventory);
        }

        private void onStats()
        {
            if (Contains(Inventory))
                RemoveChild(Inventory);

            if (!Contains(StatsView))
                AddChild(StatsView);
        }

        public void ReloadInventory(Item[] inventory) => Inventory.ReloadInventory(inventory);
        public void ReloadInventoryPlayer(GamePlayer player) => Inventory.LoadPlayerSprite(player);

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.StartClamp();
            base.Draw(spriteBatch);
            spriteBatch.EndClamp();
        }
    }
}