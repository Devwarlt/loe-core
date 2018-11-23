using LoESoft.Client.Core.Game.User.GUI.Icon;
using LoESoft.Client.Core.Game.User.GUI.UI;
using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Sprites.Forms;

namespace LoESoft.Client.Core.Game.User.GUI
{
    public class PlayerHUD : Mask
    {
        public PlayerInfoTable InfoTable { get; set; }
        public IconTab Icons { get; set; }

        public PlayerHUD()
            : base(new RGBColor(0, 0, 0), 0f)
        {
            IsEventApplicable = false;

            Icons = new IconTab(975, 5, toggleInfoTable);
            InfoTable = new PlayerInfoTable();

            AddChild(Icons);
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