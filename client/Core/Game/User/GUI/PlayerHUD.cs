using LoESoft.Client.Core.Game.User.GUI.UI;
using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Sprites.Forms;

namespace LoESoft.Client.Core.Game.User.GUI
{
    public class PlayerHUD : FilledRectangle
    {
        public PlayerInfoTable InfoTable { get; set; }

        public PlayerHUD()
            : base(0, 0, 1000, 600, new RGBColor(15, 150, 150))
        {
            IsEventApplicable = false;

            InfoTable = new PlayerInfoTable();
            AddChild(InfoTable);
        }
    }
}
