using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Sprites.Forms;
using LoESoft.Client.Drawing.Sprites.Text;

namespace LoESoft.Client.Core.Game.User.GUI.UI.Elements
{
    public class StatView : FilledRectangle
    {
        public TextDisplay Title { get; private set; }

        public TextDisplay HpText { get; private set; }

        public StatView(int x, int y)
            : base(x, y, 500, 400, new RGBColor(255, 0, 255), 1)
        {
            Title = new TextDisplay(5, 5, "Status");
            Title.Outline = true;

            HpText = new TextDisplay(5, 30, "Hp:", 10);

            AddChild(Title);
            AddChild(HpText);
        }

        public void UpdateStat(int hp)
        {
            HpText.Text = "Hp:" + hp.ToString();
        }
    }
}