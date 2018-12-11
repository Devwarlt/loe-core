using LoESoft.Client.Drawing.Sprites;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LoESoft.Client.Core.Game.User.GUI.Icon
{
    public class IconBar : Sprite
    {
        public IconBar(int x, int y, Texture2D texture, int w = 45, int h = 45)
            : base(x, y, w, h, texture, alpha: 1f)
        {
            AddEventListener(Drawing.Events.Event.CLICKLEFT, delegate
            {
                OnToggle?.Invoke();
            });
        }

        public Action OnToggle { get; set; }
    }
}