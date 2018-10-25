using LoESoft.Client.Assets;
using LoESoft.Client.Core.Game.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoESoft.Client.Core.Game.Animation
{
    public class PlayerAnimation : Animation
    {
        private int curDirection = 1;
        private int preDirection = 1;

        public PlayerAnimation()
            : base(0.1f, AnimationType.Forward) //Speed will be determined by player speed later on
        {
            //temporary loading, til proper xml managing and proper player handling is added
            var tempSpriteSet = AssetLibrary.Sprites["playersEmbed"];

            AddAnimation(AnimationType.Forward, tempSpriteSet.GetSpritesByWidth(1));
            AddAnimation(AnimationType.Backward, tempSpriteSet.GetSpritesByWidth(0));
            AddAnimation(AnimationType.Left, tempSpriteSet.GetSpritesByWidth(3));
            AddAnimation(AnimationType.Right, tempSpriteSet.GetSpritesByWidth(2));
        }

        public override void Update(GameTime gameTime, BasicObject basicObject)
        {
            preDirection = curDirection;
            curDirection = (((Player)basicObject).CurrentDirection != Player.Direction.None) ?
                (int)((Player)basicObject).CurrentDirection :
                preDirection;

            if (curDirection != preDirection)
                ChangeAnimationType((AnimationType)curDirection);

            base.Update(gameTime, basicObject);
        }

        public override void Draw(SpriteBatch spriteBatch, BasicObject basicObject)
            => Frames[(AnimationType)curDirection][CurrentFrame].Draw(spriteBatch, basicObject);
    }
}