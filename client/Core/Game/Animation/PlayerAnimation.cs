using LoESoft.Client.Assets;
using LoESoft.Client.Assets.Xml.Structure;
using LoESoft.Client.Core.Game.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static LoESoft.Client.Core.Game.Objects.Player;

namespace LoESoft.Client.Core.Game.Animation
{
    public class PlayerAnimation : Animation
    {
        private int curDirection = 1;
        private int preDirection = 1;

        public PlayerAnimation()
            : base(0.1f, AnimationType.Forward)
        {
        }

        public void UpdateOrAdd(ObjectsContent content)
        {
            var animation = XmlLibrary.GetPlayerAnimation(content);

            AddAnimation(AnimationType.Forward, animation[1]);
            AddAnimation(AnimationType.Backward, animation[0]);
            AddAnimation(AnimationType.Left, animation[3]);
            AddAnimation(AnimationType.Right, animation[2]);
        }

        public override void Update(GameTime gameTime, Entity basicObject)
        {
            preDirection = curDirection;
            curDirection = (((Player)basicObject).CurrentDirection != Direction.None) ?
                (int)((Player)basicObject).CurrentDirection : preDirection;

            if (curDirection != preDirection)
                ChangeAnimationType((AnimationType)curDirection);

            base.Update(gameTime, basicObject);
        }

        public override void Draw(SpriteBatch spriteBatch, Entity entity)
        {
            Frames[(AnimationType)curDirection][CurrentFrame].Draw(spriteBatch, entity);
        }
    }
}