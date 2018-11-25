using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Sprites.Forms;
using LoESoft.Client.Drawing.Sprites.Text;

namespace LoESoft.Client.Core.Game.User.GUI.UI.Elements.UI
{
    public class DescriptionPanel : Panel
    {
        public TextDisplay Description { get; set; }

        public DescriptionPanel(int x, int y, string title) 
            : base(x, y, title, 400, 400, new RGBColor(25, 25, 70), 0.75f)
        {
            Description = new TextDisplay(5, 30, "Test test test test test test est");
            Description.PerLineWidth = 300;

            AddChild(Description);
        }
    }
}
