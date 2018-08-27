using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoESoft.Client.Core.Game.Animation
{
    public abstract class Animation
    {
        public int CurrentFrame;
        public int FramesPerSecond;
        public AnimationFrame[] Frames;

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
