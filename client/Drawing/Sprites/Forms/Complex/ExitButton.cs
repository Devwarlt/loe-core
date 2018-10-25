using LoESoft.Client.Assets;
using LoESoft.Client.Drawing.Events;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LoESoft.Client.Drawing.Sprites.Forms.Complex
{
    public class ExitButton : Sprite
    {
        private Action _exit;

        public event Action Exit
        {
            add { _exit += value; }
            remove { _exit -= value; }
        }

        public ExitButton(int x, int y, int width, int height, RGBColor color = null)
            : base(x, y, width, height, AssetLibrary.Images["exitImage"], color)
            => AddEventListener(Event.CLICKLEFT, OnExit);

        private void OnExit(object sender, EventArgs e)
        {
            _exit?.Invoke();

            ParentSprite.ParentSprite.RemoveChild(ParentSprite);
        }
    }
}