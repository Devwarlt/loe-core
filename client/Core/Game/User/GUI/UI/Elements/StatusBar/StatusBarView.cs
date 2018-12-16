using LoESoft.Client.Assets;
using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Sprites;
using LoESoft.Client.Drawing.Sprites.Forms;
using LoESoft.Client.Drawing.Sprites.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoESoft.Client.Core.Game.User.GUI.UI.Elements.StatusBar
{
    public class StatusBarView : FilledRectangle
    {
        private Sprite _statusImage;
        private FilledRectangle _statusBar;

        protected int StaticWidth { get; set; }

        public int MaximumValue { get; set; }
        private int _currentValue;
        public int CurrentValue
        {
            get => _currentValue;
            set
            {
                ValueText.Text = $"{value}/{MaximumValue}";
                _currentValue = value;
            }
        }

        public TextDisplay BarText { get; set; }
        public TextDisplay ValueText { get; set; }

        public StatusBarView(int x, int y, int w, int h, string name, RGBColor color, int max = 100)
            : base (x, y, w, h, new RGBColor(65, 75, 86))
        {
            _statusBar = new FilledRectangle(0, 0, w, h, color);

            int ty = DrawHelper.CenteredPosition(h, TextDisplay.GetHeight(12));
            int tx = (int)TextDisplay.MeasureString(name).X + 25;

            BarText = new TextDisplay(10, ty, name + ":", 10);
            ValueText = new TextDisplay(tx, ty, max.ToString(), 10);
            _statusImage = new Sprite(-5, -5, w + 10, h + 10, AssetLibrary.Images["statusBarRect"]);

            MaximumValue = max;
            CurrentValue = MaximumValue;
            StaticWidth = w;

            AddChild(_statusBar);
            AddChild(BarText);
            AddChild(ValueText);
            AddChild(_statusImage);
        }

        public void UpdateStatus(int max, int cur)
        {
            CurrentValue = cur;
            MaximumValue = max;
        }

        public override void Update(GameTime gameTime)
        {
            //Yes casting are needed! since | int < 0 / int < 0 == 0 | 
            double width = ((double)(CurrentValue + 1) / (double)(MaximumValue + 1)) * StaticWidth;
            _statusBar.Width = (int)width;

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.StartClamp();
            base.Draw(spriteBatch);
            spriteBatch.EndClamp();
        }
    }
}
