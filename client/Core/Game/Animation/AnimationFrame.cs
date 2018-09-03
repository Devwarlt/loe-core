using LoESoft.Client.Core.Game.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoESoft.Client.Core.Game.Animation
{
    public class AnimationFrame
    {
        public Texture2D Texture;

        public AnimationFrame(Texture2D texture)
        {
            Texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch, BasicObject obj)
        => spriteBatch.Draw(Texture, new Vector2(obj.DrawX, obj.DrawY), new Rectangle(0, 0, obj.Size, obj.Size), Color.White);
    }
}
