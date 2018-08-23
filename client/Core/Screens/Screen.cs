using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoESoft.Client.Core.Screens
{
    public abstract class Screen
    {
        public bool Visible { get; set; } = true;

        public abstract void OnScreenCreate();
        public abstract void OnScreenDispatch();

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
