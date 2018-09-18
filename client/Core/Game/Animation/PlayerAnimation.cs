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
            //temporary loading, til proper xml managing and proper player handling is added
            AddAnimation(AnimationType.Forward,
                AssetLoader.LoadSpriteSet("playersEmbed").GetSpritesByWidth(0));
            AddAnimation(AnimationType.Backward,
               AssetLoader.LoadSpriteSet("playersEmbed").GetSpritesByWidth(1));
            AddAnimation(AnimationType.Left,
               AssetLoader.LoadSpriteSet("playersEmbed").GetSpritesByWidth(2));
            AddAnimation(AnimationType.Right,
               AssetLoader.LoadSpriteSet("playersEmbed").GetSpritesByWidth(3));
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
