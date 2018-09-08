using LoESoft.Client.Core.Game.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LoESoft.Client.Core.Game.Animation
{
    public enum AnimationType : byte
    {
        Singular = 0, // For enemies with only 1 type of animation EX: Monsters, Decor entities/tiles
        Forward = 1,
        Backward = 2,
        Left = 3,
        Right = 4,
        Fighting = 5
    }
    public abstract class Animation
    {
        public int CurrentFrame { get; private set; }
        public float CoolDown { get; private set; }
        public Dictionary<AnimationType, List<AnimationFrame>> Frames { get; private set; }

        protected float Timer = 0f;

        public Animation(float coolDown)
        {
            Frames = new Dictionary<AnimationType, List<AnimationFrame>>();
            CoolDown = coolDown;
            CurrentFrame = 0;
        }

        public void AddAnimation(AnimationType type, Texture2D[] textures)
        {
            List<AnimationFrame> frames = new List<AnimationFrame>();

            foreach (var i in textures)
                frames.Add(new AnimationFrame(i));

            Frames.Add(type, frames);
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
