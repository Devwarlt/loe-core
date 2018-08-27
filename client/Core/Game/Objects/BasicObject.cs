using LoESoft.Client.Assets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;

namespace LoESoft.Client.Core.Game.Objects
{
    public class BasicObject // test class
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float DrawX => X * 8;
        public float DrawY => Y * 8;
        public Texture2D Texture { get; set; }

        public void Update(GameTime gameTime) { }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (Texture == null)
                Texture = AssetLibrary.Images.Values.First();

            spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: Camera.GetMatrix());
            spriteBatch.Draw(Texture, new Vector2(X, Y), new Rectangle(0, 0, 8, 8), Color.White);
            spriteBatch.End();
        }
    }
}
