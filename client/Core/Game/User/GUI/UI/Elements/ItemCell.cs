using LoESoft.Client.Assets.Xml;
using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Sprites;
using LoESoft.Client.Drawing.Sprites.Forms;

namespace LoESoft.Client.Core.Game.User.GUI.UI.Elements
{
    public class ItemCell : FilledRectangle
    {
        public Sprite ItemSprite { get; set; }

        public ItemCell(int x, int y)
            : base(x, y, 50, 50, new RGBColor(26, 100, 0), 1)
        {
        }

        public void Init(int id)
        {
            var property = XmlLibrary.ItemsXml[id];
            ItemSprite = new Sprite(5, 5, 40, 40, XmlLibrary.GetSpriteFromContent(property));
            AddChild(ItemSprite);
        }
    }
}