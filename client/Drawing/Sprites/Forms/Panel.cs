﻿using LoESoft.Client.Assets;
using LoESoft.Client.Drawing.Sprites.Forms.Complex;
using LoESoft.Client.Drawing.Sprites.Text;
using Microsoft.Xna.Framework;
using System;

namespace LoESoft.Client.Drawing.Sprites.Forms
{
    public class Panel : Sprite
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
            : base(x, y, width, height, AssetLibrary.Images["panelImage"], color, opacity)
        {
            Title = new TextDisplay(5, 10, title);

            ExitBtn = new ExitButton(width - (20 + (width / 50)),(width / 50), 20, 20);
            ExitBtn.Exit += OnExit;

            AddChild(Title);
            AddChild(ExitBtn);
        }

        public override void Update(GameTime gameTime)
        {
            Title.X = DrawHelper.CenteredPosition(Width, Title.Width);
            base.Update(gameTime);
        }

        public virtual void OnExit()
        {
            _onPanelExit?.Invoke();
        }
    }
}