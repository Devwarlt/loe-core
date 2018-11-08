using LoESoft.Client.Core.Game.Animation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoESoft.Client.Core.Game.Objects
{
    public class EntityObject : Entity
    {
        private ObjectAnimation Animation;

        public EntityObject() : base(6)
        {
            Animation = new ObjectAnimation();
        }

        public void Init()
        {
            Animation.InitOrUpdate(Content);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Animation.Draw(spriteBatch, this);
        }

        public override void Update(GameTime gameTime)
        {
            Animation.Update(gameTime, this);
            base.Update(gameTime);
        }
    }
}