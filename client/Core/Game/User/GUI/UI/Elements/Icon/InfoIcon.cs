using System;
using LoESoft.Client.Core.Game.User.GUI.Icon;
using LoESoft.Client.Assets;
using Microsoft.Xna.Framework.Graphics;
using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Sprites.Forms;

namespace LoESoft.Client.Core.Game.User.GUI.UI.Elements.Icon
{
    public class InfoIcon : FilledRectangle
    {
        public IconBar InventoryTab { get; set; }
        public IconBar StatsTab { get; set; }

        public InfoIcon(int x, int y, Action onInv, Action onStats) 
            :base(x, y, 70, 40, new RGBColor(71, 40, 40)) //AssetLibrary.Images["titleDisplayRect"]
        {
            var set = AssetLibrary.Sprites["iconSprites"];
            InventoryTab = new IconBar(5, 5, set.GetSprite(0, 1), 30, 30);
            InventoryTab.OnToggle = onInv;
            StatsTab = new IconBar(35, 5, set.GetSprite(1, 1), 30, 30);
            StatsTab.OnToggle = onStats;

            AddChild(InventoryTab);
            AddChild(StatsTab);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.StartClamp();
            base.Draw(spriteBatch);
            spriteBatch.EndClamp();
        }
    }
}
