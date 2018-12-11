using LoESoft.Client.Assets;
using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Sprites.Forms;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LoESoft.Client.Core.Game.User.GUI.Icon
{
    public partial class IconTab : FilledRectangle
    {
        public IconBar OptionIcon { get; set; } //To toggle options
        public IconBar InfoIcon { get; set; } //To toggle playerinfotable
        public IconBar MiniMapIcon { get; set; } //To toggle minimap
        public IconBar ChatIcon { get; set; } //To toggle chat

        public IconTab(int x, int y, Action onInfo, Action onOption, Action onMiniMap, Action onChat = null)
            : base(x, y, 225, 50, new RGBColor(25, 25, 75), 0.7f)
        {
            var iconSet = AssetLibrary.Sprites["iconSprites"];

            InfoIcon = new IconBar(5, 2, iconSet.GetSprite(0, 0));
            InfoIcon.OnToggle = onInfo;
            OptionIcon = new IconBar(60, 2, iconSet.GetSprite(1, 0));
            OptionIcon.OnToggle = onOption;
            MiniMapIcon = new IconBar(115, 2, iconSet.GetSprite(2, 0));
            MiniMapIcon.OnToggle = onMiniMap;
            ChatIcon = new IconBar(170, 2, iconSet.GetSprite(3, 0));
            ChatIcon.OnToggle = onChat;

            AddChild(InfoIcon);
            AddChild(OptionIcon);
            AddChild(MiniMapIcon);
            AddChild(ChatIcon);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.StartClamp();
            base.Draw(spriteBatch);
            spriteBatch.EndClamp();
        }
    }
}