using LoESoft.Client.Core.Game.User.GUI.Icon;
using LoESoft.Client.Core.Game.User.GUI.UI;
using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Sprites.Forms;

namespace LoESoft.Client.Core.Game.User.GUI
{
    public class PlayerHUD : Mask
    {
        public PlayerInfoTable InfoTable { get; set; }
        public OptionsTable OptionTable { get; set; }
        public MiniMap MiniMapView { get; set; }
        public IconTab Icons { get; set; }

        public PlayerHUD()
            : base(new RGBColor(0, 0, 0), 0f)
        {
            IsEventApplicable = false;

            Icons = new IconTab(975, 5, toggleInfoTable, toggleOptions, toggleMinimap);
            InfoTable = new PlayerInfoTable();
            OptionTable = new OptionsTable();
            MiniMapView = new MiniMap(900, 60);

            AddChild(Icons);
        }

        public void UpdateUI(GamePlayer player)
        {
            if (player.Player.IsMoving && Icons.ChildList.Contains(MiniMapView))
                MiniMapView.ReloadMap((int)player.Player.X, (int)player.Player.Y);
        }

        private void toggleOptions()
        {
            if (Icons.ChildList.Contains(OptionTable))
                Icons.RemoveChild(OptionTable);
            else
                Icons.AddChild(OptionTable);
        }

        private void toggleMinimap()
        {
            if (Icons.ChildList.Contains(MiniMapView))
                Icons.RemoveChild(MiniMapView);
            else
                Icons.AddChild(MiniMapView);
        }

        private void toggleInfoTable()
        {
            if (Icons.ChildList.Contains(InfoTable))
                Icons.RemoveChild(InfoTable);
            else
                Icons.AddChild(InfoTable);
        }
    }
}