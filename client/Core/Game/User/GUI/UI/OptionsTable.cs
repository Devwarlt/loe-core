using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Sprites.Forms;

namespace LoESoft.Client.Core.Game.User.GUI.UI
{
    public class OptionsTable : Panel
    {
        public OptionsTable()
            : base(DrawHelper.CenteredToScreenWidth(400), DrawHelper.CenteredToScreenHeight(400), "Options", 400, 400, new RGBColor(255, 255, 255), 0.9f)
        {
            IsZeroApplicaple = true;
        }
    }
}