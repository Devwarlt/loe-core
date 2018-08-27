using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public class AnimationFrame
    {
        public Texture2D Texture;

        public AnimationFrame(Texture2D texture)
        {
            Texture = texture;   
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
