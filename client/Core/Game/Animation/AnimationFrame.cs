using LoESoft.Client.Core.Game.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoESoft.Client.Core.Game.Animation
{
    public class AnimationFrame
    {
        public Texture2D Texture { get; set; }

        public AnimationFrame(Texture2D texture, SpriteEffects effect = SpriteEffects.None) => Texture = texture;

        public void Draw(SpriteBatch spriteBatch, GameObject obj)
            => spriteBatch.Draw(Texture, new Rectangle((int)obj.DrawX - ((obj.Size / 2) - (4)), (int)obj.DrawY - (obj.Size) + 4, obj.Size, obj.Size), Color.White);
    }
}