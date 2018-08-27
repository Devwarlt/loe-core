using LoESoft.Client.Drawing.Sprites.Forms.Complex;
using LoESoft.Client.Drawing.Sprites.Text;

namespace LoESoft.Client.Drawing.Sprites.Forms
{
    public class Panel : FilledRectangle
    {
        public TextDisplay Title { get; private set; }

        protected Mask _grayMask;

        protected ExitButton _exitBtn;

        public Panel(int x, int y, string title, int width = 400, int height = 400, RGBColor color = null)
            : base(x, y, width, height, color)
        {
            var textpos = TextDisplay.MeasureString(title);
            Title = new TextDisplay(((width / 2) - ((int)textpos.X / 2)), 5, title);
            _exitBtn = new ExitButton(width - 23, 3, 20, 20);
            _exitBtn.Exit += OnExit;

            AddChild(Title);
            AddChild(_exitBtn);
        }

        public virtual void OnExit()
        {
        }
    }
}
