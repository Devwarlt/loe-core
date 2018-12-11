using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Sprites.Forms;
using LoESoft.Client.Drawing.Sprites.Text;
using Microsoft.Xna.Framework;

namespace LoESoft.Client.Core.Game.User.GUI.UI.Elements.StatusBar
{
    public class StatusBarView : FilledRectangle
    {
        protected int StaticWidth { get; set; } = 100;

        public int MaximumValue { get; set; } = 100;
        private int _currentValue = 100;
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
            : base (x, y, w, h, color)
        {
            int ty = DrawHelper.CenteredPosition(h, TextDisplay.GetHeight(12));
            BarText = new TextDisplay(5, ty, name + ":");
            int tx = (int)TextDisplay.MeasureString(name).X + 10;
            ValueText = new TextDisplay(tx, ty, max.ToString());

            MaximumValue = max;
            CurrentValue = MaximumValue;
            StaticWidth = w;

            AddChild(BarText);
            AddChild(ValueText);
        }

        public override void Update(GameTime gameTime)
        {
            Width = StaticWidth * ((CurrentValue) / (MaximumValue));
            base.Update(gameTime);
        }
    }
}
