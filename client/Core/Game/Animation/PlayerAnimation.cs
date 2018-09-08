using LoESoft.Client.Assets;
using LoESoft.Client.Core.Game.Objects;
using Microsoft.Xna.Framework.Graphics;

namespace LoESoft.Client.Core.Game.Animation
{
    public class PlayerAnimation : Animation
    {
        public PlayerAnimation(Player player)
            : base(0.5f)
        {
            AddAnimation(AnimationType.Forward, AssetLibrary.GetAnimationTexture(1, 0));//1 is for test
            AddAnimation(AnimationType.Backward, AssetLibrary.GetAnimationTexture(1, 1));
            AddAnimation(AnimationType.Left, AssetLibrary.GetAnimationTexture(1, 2));
            AddAnimation(AnimationType.Right, AssetLibrary.GetAnimationTexture(1, 3));
        }

        int curDirection = 0;
        int preDirection = 0;
        public override void Draw(SpriteBatch spriteBatch, BasicObject basicObject)
        {
            var player = (Player)basicObject;
            preDirection = curDirection;
            curDirection = (player.CurrentDirection != Player.Direction.None) ? (int)player.CurrentDirection : preDirection;

            Frames[(AnimationType)curDirection][CurrentFrame].Draw(spriteBatch, player);
        }
    }
}
