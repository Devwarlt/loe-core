using LoESoft.Client.Core.Game.Objects;
using Microsoft.Xna.Framework.Graphics;

namespace LoESoft.Client.Core.Game.Animation
{
    public class PlayerAnimation : Animation
    {
        public PlayerAnimation(Texture2D[] textures) : base(textures, 0.5f) { }

        // TODO: do something.
        public override void Draw(SpriteBatch spriteBatch, BasicObject obj) { }
    }
}
