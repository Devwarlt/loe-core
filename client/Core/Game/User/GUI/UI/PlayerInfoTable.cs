using LoESoft.Client.Core.Client;
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

        public PlayerInfoTable(GameUser user)
            : base(DrawHelper.CenteredToScreenWidth(600), DrawHelper.CenteredToScreenHeight(600), "PlayerInfo", 600, 600, new RGBColor(255, 255, 255), 0.95f)
        {
            IsZeroApplicaple = true;

            Inventory = new InventoryView(user, 100, 325);
            //StatsView = new StatView(50, 555);
            //AddChild(StatsView);
            AddChild(Inventory);
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