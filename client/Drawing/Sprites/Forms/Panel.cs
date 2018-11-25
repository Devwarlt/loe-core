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

        public Panel(int x, int y, string title, int width = 400, int height = 400, RGBColor color = null, float opacity = 1f)
            : base(x, y, width, height, color, opacity)
        {
            Title = new TextDisplay(5, 5, title);
            Title.X = DrawHelper.CenteredPosition(width, Title.Width);

            ExitBtn = new ExitButton(width - 23, 3, 20, 20);
            ExitBtn.Exit += OnExit;
            
            AddChild(Title);
            AddChild(ExitBtn);
        }

        public virtual void OnExit()
        {
            _onPanelExit?.Invoke();
        }
    }
}