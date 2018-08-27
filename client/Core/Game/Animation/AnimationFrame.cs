using Microsoft.Xna.Framework.Graphics;

namespace LoESoft.Client.Core.Game.Animation
{
    public class AnimationFrame
    {
        public Texture2D Texture;

        public AnimationFrame(Texture2D texture)
        {
            Texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch) { }
    }
}
