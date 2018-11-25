using LoESoft.Client.Assets.Xml;
using LoESoft.Client.Core.Game.User.GUI.UI.Elements.UI;
using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Events;
using LoESoft.Client.Drawing.Sprites;
using LoESoft.Client.Drawing.Sprites.Forms;

namespace LoESoft.Client.Core.Game.User.GUI.UI.Elements
{
    public class ItemCell : FilledRectangle
    {
        public Sprite ItemSprite { get; set; }

        protected DescriptionPanel Description { get; set; }

        public ItemCell(int x, int y)
            : base(x, y, 50, 50, new RGBColor(26, 100, 0), 1)
        {
            Description = new DescriptionPanel(DrawHelper.CenteredToScreenWidth(300), DrawHelper.CenteredToScreenHeight(400), "");
            Description.IsZeroApplicaple = true;


            AddEventListener(Event.CLICKLEFT, delegate
            {
                AddChild(Description);
            });
        }

        public void Init(int id)
        {
            var property = XmlLibrary.ItemsXml[id];
            ItemSprite = new Sprite(5, 5, 40, 40, XmlLibrary.GetSpriteFromContent(property));
            ItemSprite.IsEventApplicable = false;
            Description.Title.Text = property.Name;
            AddChild(ItemSprite);
        }
    }
}