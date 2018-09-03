using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoESoft.Client.Core.Game.Objects;
using Microsoft.Xna.Framework.Graphics;

namespace LoESoft.Client.Core.Game.Animation
{
    public class PlayerAnimation : Animation
    {
        public PlayerAnimation(Texture2D[] textures)
            : base (textures, 0.5f)
        {

        }

        public override void Draw(SpriteBatch spriteBatch, BasicObject obj)
        {
            //Do something
        }
    }
}
