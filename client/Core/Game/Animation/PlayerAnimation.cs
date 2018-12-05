using LoESoft.Client.Assets.Xml;
using LoESoft.Client.Assets.Xml.Structure;
using LoESoft.Client.Core.Game.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoESoft.Client.Core.Game.Animation
{
    public class PlayerAnimation : Animation
    {
        private int curDirection;
        private int preDirection;

        public PlayerAnimation()
            : base(500f, AnimationType.Forward)
        {
            curDirection = 1;
            preDirection = curDirection;
        }

        public void UpdateOrAdd(ObjectsContent content)
        {
            var animation = XmlLibrary.GetAnimation(content);

            AddAnimation(AnimationType.Forward, animation[0]);
            AddAnimation(AnimationType.Backward, animation[1]);
            AddAnimation(AnimationType.Left, animation[3]);
            AddAnimation(AnimationType.Right, animation[2]);
        }

        public override void Update(GameTime gameTime, GameObject basicObject)
        {
            preDirection = curDirection;
            curDirection = (int)((Player)basicObject).CurrentDirection + 1;

            if (curDirection != preDirection)
                ChangeAnimationType((AnimationType)curDirection);

            base.Update(gameTime, basicObject);
        }

        public override void Draw(SpriteBatch spriteBatch, GameObject entity) =>
            Frames[(AnimationType)curDirection][CurrentFrame].Draw(spriteBatch, entity);
    }
}