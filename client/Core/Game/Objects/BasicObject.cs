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

        //need 2 implement a asset loader for the objects b4 the base class is done
        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (Texture == null)
                Texture = AssetLibrary.Images.Values.First();

            spriteBatch.Draw(Texture, new Vector2(DrawX, DrawY), new Rectangle(0, 0, 8, 8), Color.White);
        }
    }
}
