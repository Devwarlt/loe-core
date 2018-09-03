using LoESoft.Client.Core.Game.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LoESoft.Client.Core.Game.Animation
{
    public abstract class Animation
    {
        public int CurrentFrame { get; private set; }
        public float CoolDown { get; private set; }
        public List<AnimationFrame> Frames { get; private set; }

        protected float Timer = 0f;

        public Animation(Texture2D[] textures, float coolDown)
        {
            foreach (var i in textures)
                Frames.Add(new AnimationFrame(i));

            CoolDown = coolDown;
        }

        public virtual void Update(GameTime gameTime)
        {
            Timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            
            if (Timer >= CoolDown)
            {
                CurrentFrame++;
                
                if (CurrentFrame >= Frames.Count)
                    CurrentFrame = 0;

                Timer = 0f;
            }
        }

        public abstract void Draw(SpriteBatch spriteBatch, BasicObject obj); //Draw should differentuate between types: Enemy, Player, Animated tiles / effects
    }
}
