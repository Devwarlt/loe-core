using LoESoft.Client.Assets.Xml;
using LoESoft.Client.Assets.Xml.Structure;
using LoESoft.Client.Core.Game.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoESoft.Client.Core.Game.Animation
{
    public class ObjectAnimation : Animation
    {
        public ObjectAnimation()
            : base(0.1f)
        {
        }

        public void InitOrUpdate(ObjectsContent content)
        {
            var animation = XmlLibrary.GetObjectAnimation(content);

            AddAnimation(AnimationType.Singular, animation);
        }

        public override void Update(GameTime gameTime, Entity basicObject) => base.Update(gameTime, basicObject);

        public override void Draw(SpriteBatch spriteBatch, Entity entity)
        {
            Frames[AnimationType.Singular][CurrentFrame].Draw(spriteBatch, entity);
        }
    }
}