using LoESoft.Client.Core.Game.User.GUI.UI.Elements;
using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Sprites.Forms;

namespace LoESoft.Client.Core.Game.User.GUI.UI
{
    //Displays Inventory and Stats And Stuff
    public class PlayerInfoTable : FilledRectangle
    {
        public InventoryView Inventory { get; set; }
        public StatView StatsView { get; set; }

        public PlayerInfoTable()
            : base(DrawHelper.CenteredToScreenWidth(800), DrawHelper.CenteredToScreenHeight(600), 800, 600, new RGBColor(25, 150, 155), 1)
        {
            IsZeroApplicaple = true;

            Inventory = new InventoryView(390, 10);

            AddChild(Inventory);
        }
    }
}
