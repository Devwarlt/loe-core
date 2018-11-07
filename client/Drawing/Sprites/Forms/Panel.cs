using LoESoft.Client.Drawing.Sprites.Forms.Complex;
using LoESoft.Client.Drawing.Sprites.Text;
using System;

namespace LoESoft.Client.Drawing.Sprites.Forms
{
    public class Panel : FilledRectangle
    {
        public TextDisplay Title { get; private set; }

        public event Action OnPanelExit
        {
            add { _onPanelExit += value; }
            remove { _onPanelExit -= value; }
        }

        private Action _onPanelExit;

        protected ExitButton ExitBtn;
        protected Mask GrayMask;

        public Panel(int x, int y, string title, int width = 400, int height = 400, RGBColor color = null)
            : base(x, y, width, height, color)
        {
            Title = new TextDisplay((width / 2) - ((int)TextDisplay.MeasureString(title).X / 2), 5, title);
            ExitBtn = new ExitButton(width - 23, 3, 20, 20);
            ExitBtn.Exit += OnExit;

            AddChild(Title);
            AddChild(ExitBtn);
        }

        public virtual void OnExit() => _onPanelExit?.Invoke();
    }
}