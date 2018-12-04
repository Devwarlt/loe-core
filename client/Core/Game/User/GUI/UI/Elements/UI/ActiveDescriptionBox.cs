using LoESoft.Client.Assets.Xml.Structure;
using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Sprites.Forms;
using LoESoft.Client.Drawing.Sprites.Text;

namespace LoESoft.Client.Core.Game.User.GUI.UI.Elements.UI
{
    public class ActiveDescriptionBox : FilledRectangle
    {
        public TextDisplay TitleText { get; set; }
        public TextDisplay DescriptionText { get; set; }
        
        public ActiveDescriptionBox(int x, int y) 
            : base(x, y, 250, 200, new RGBColor(106, 103, 23), 0.75f)
        {
            IsZeroApplicaple = true;

            TitleText = new TextDisplay(5, 5, "");
            TitleText.WrapWidth = 240;
            DescriptionText = new TextDisplay(5, 30, "", 9);
            DescriptionText.WrapWidth = 240;
            
            AddChild(TitleText);
            AddChild(DescriptionText);
        }

        public void Reload(XmlContent content)
        {
            TitleText.Text = content.Name;
            DescriptionText.Text = "Sample Description";
        }
    }
}
