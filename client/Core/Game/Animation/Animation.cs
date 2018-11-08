using LoESoft.Client.Core.Game.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace LoESoft.Client.Core.Game.Animation
{
    public abstract class Animation
    {
        public int CurrentFrame { get; set; }
        public float CoolDown { get; private set; }
        public Dictionary<AnimationType, List<AnimationFrame>> Frames { get; private set; }
        public AnimationType TypeAnimation { get; set; }

        protected float Timer = 0f;

        public Animation(float coolDown, AnimationType initType = AnimationType.Singular)
        {
            Frames = new Dictionary<AnimationType, List<AnimationFrame>>();
            TypeAnimation = initType;
            CoolDown = coolDown;
            CurrentFrame = 0;
        }

        public void AddAnimation(AnimationType type, List<Texture2D> textures) 
            => Frames.Add(type, textures.Select(_ => new AnimationFrame(_)).ToList());
        
        public void ChangeAnimationType(AnimationType type)
        {
            CurrentFrame = 0;
            TypeAnimation = type;
        }

        public virtual void Update(GameTime gameTime, Entity basicObject)
        {
            Timer += (float) gameTime.ElapsedGameTime.TotalSeconds;

            if (Timer >= CoolDown)
            {
                if (!basicObject.IsMoving)
                {
                    CurrentFrame = 0;
                    return;
                }

                CurrentFrame++;

                if (CurrentFrame >= Frames[TypeAnimation].Count)
                    CurrentFrame = 0;

                Timer = 0f;
            }
        }

        public abstract void Draw(SpriteBatch spriteBatch, Entity entity); //Draw should differentuate between types: Enemy, Player, Animated tiles / effects
    }
}