using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Sprites.Forms;

namespace LoESoft.Client.Core.Game.User.GUI.UI
{
    public class OptionsTable : Panel
    {
        public OptionsTable() 
            : base(DrawHelper.CenteredToScreenWidth(600), DrawHelper.CenteredToScreenHeight(600), "Options", 600, 600, new RGBColor(65, 32, 45), 0.9f)
        {
            IsZeroApplicaple = true;
        }
    }
}