using LoESoft.Client.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoESoft.Client.Core.Screens
{
    public class GameScreen : Screen
    {
        public override void OnScreenCreate() { }
        public override void OnScreenDispatch() { }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.ClearColor(Color.Orange);
        }
    }
}
