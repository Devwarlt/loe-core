using LoESoft.Client.Assets;
using LoESoft.Client.Drawing.Sprites.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoESoft.Client.Drawing.Sprites.Forms
{
    public class Button : Sprite
    {
        public TextDisplay NameText { get; set; }

        public Button(int x, int y, string name, RGBColor color = null, float alpha = 1)
            : base(x, y, 0, 0, AssetLoader.LoadAsset<Texture2D>("images/btnImage"), color, alpha)
        {
            NameText = new TextDisplay(5, 5, name);

            var textwidth = (int)TextDisplay.MeasureString(name).X;
            var textheight = (int)TextDisplay.MeasureString(name).Y;

            Width = textwidth + 10;
            Height = textheight + 10;

            AddChild(NameText);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
