using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Sprites.Forms;
using LoESoft.Client.Drawing.Sprites.Text;
using Microsoft.Xna.Framework;

namespace LoESoft.Client.Core.Game.User.GUI.UI.Elements.UI
{
    public class DescriptionPanel : Panel
    {
        public TextDisplay Description { get; set; }

        public DescriptionPanel(int x, int y, string title) 
            : base(x, y, title, 400, 400, new RGBColor(25, 25, 70), 0.75f)
        {
            Description = new TextDisplay(5, 30, "This is a sample description Test sample hey");
            Description.WrapWidth = 400;
            AddChild(Description);

            Height = Title.Height + Description.Height + 20;
        }

        public override void Update(GameTime gameTime)
        {
            Height = Title.Height + Description.Height + 20;
            base.Update(gameTime);
        }
    }
}
