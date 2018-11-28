using LoESoft.Client.Assets.Xml;
using LoESoft.Client.Assets.Xml.Structure;
using LoESoft.Client.Core.Game.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoESoft.Client.Core.Game.Animation
{
    public class ObjectAnimation : Animation
    {
        private int curDirection;
        private int preDirection;

        public ObjectAnimation()
            : base(0.1f, AnimationType.Forward)
        {
            curDirection = 1;
            preDirection = curDirection;
        }

        public void UpdateOrAdd(ObjectsContent content)
        {
            var animation = XmlLibrary.GetAnimation(content);

            AddAnimation(AnimationType.Forward, animation[0]);
            AddAnimation(AnimationType.Backward, animation[1]);
            AddAnimation(AnimationType.Left, animation[2]);
            AddAnimation(AnimationType.Right, animation[3]);
        }

        public override void Update(GameTime gameTime, GameObject basicObject)
        {
            preDirection = curDirection;
            curDirection = (int)((Entity)basicObject).CurrentDirection + 1;

            if (curDirection != preDirection)
                ChangeAnimationType((AnimationType)curDirection);

            base.Update(gameTime, basicObject);
        }

        public override void Draw(SpriteBatch spriteBatch, GameObject entity) =>
            Frames[(AnimationType)curDirection][CurrentFrame].Draw(spriteBatch, entity);
    }
}