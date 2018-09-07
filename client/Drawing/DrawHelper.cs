using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoESoft.Client.Drawing
{
    public static class DrawHelper
    {
        private static Texture2D TextureRect { get; set; }

        public static GraphicsDevice GraphicsDevice { get; set; }
        public static SpriteBatch SpriteBatch { get; set; }

        public static void Setup(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
        {
            GraphicsDevice = graphicsDevice;
            SpriteBatch = spriteBatch;

            TextureRect = new Texture2D(graphicsDevice, 1, 1);
            TextureRect.SetData(new Color[] { Color.White });
        }

        public static int CenteredPosition(int v1, int v2) => (v1 / 2) - (v2 / 2);

        public static void Clear(this SpriteBatch spriteBatch) => ClearColor(spriteBatch, Color.Black);
        public static void ClearColor(this SpriteBatch spriteBatch, Color color) => GraphicsDevice.Clear(color);
        public static void ClearColor(this SpriteBatch spriteBatch, float r, float g, float b) => GraphicsDevice.Clear(new Color(r, g, b));
        public static void ClearColor(this SpriteBatch spriteBatch, byte r, byte g, byte b) => GraphicsDevice.Clear(new Color(r, g, b));
        public static void ClearColor(this SpriteBatch spriteBatch, float r, float g, float b, float a) => GraphicsDevice.Clear(new Color(r, g, b, a));
        public static void ClearColor(this SpriteBatch spriteBatch, byte r, byte g, byte b, byte a) => GraphicsDevice.Clear(new Color(r, g, b, a));
        public static void ClearColor(this SpriteBatch spriteBatch, uint hex) => GraphicsDevice.Clear(new Color(hex));

        public static void DrawRectangle(this SpriteBatch spriteBatch, int x, int y, int width, int height) => DrawRectangle(spriteBatch, x, y, width, height, Color.White);
        public static void DrawRectangle(this SpriteBatch spriteBatch, int x, int y, int width, int height, Color color) => spriteBatch.Draw(TextureRect, new Vector2(x, y), new Rectangle(x, y, width, height), color);
    }
}
