﻿using LoESoft.Client.Drawing.Sprites.Forms.Complex;
using LoESoft.Client.Drawing.Sprites.Text;
using System;

namespace LoESoft.Client.Drawing.Sprites.Forms
{
    public class Panel : FilledRectangle
    {
        public TextDisplay Title { get; private set; }

        protected Mask _grayMask;

        protected ExitButton _exitBtn;

        private Action _panelExit;
        public event Action OnPanelExit
        {
            add { _panelExit += value; }
            remove { _panelExit -= value; }
        }

        public Panel(int x, int y, string title, int width = 400, int height = 400, RGBColor color = null)
            : base(x, y, width, height, color)
        {
            Title = new TextDisplay((width / 2) - ((int)TextDisplay.MeasureString(title).X / 2), 5, title);
            _exitBtn = new ExitButton(width - 23, 3, 20, 20);
            _exitBtn.Exit += OnExit;

            AddChild(Title);
            AddChild(_exitBtn);
        }

        public virtual void OnExit()
        {
            _panelExit?.Invoke();
        }
    }
}