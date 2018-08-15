using Microsoft.Xna.Framework;
using System;

namespace LoESoft.Client.Drawing.Sprites
{
    public class Sprite
    {
        public int StageX { get; private set; }
        public int StageY { get; private set; }
        public int X { get; set; }
        public int Y { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle SpriteRectangle
        {
            get { return new Rectangle(X, Y, Width, Height); }
        }

        public Sprite(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public void Update(GameTime gameTime)
        {
            Console.WriteLine($"X:{X}, Y:{Y}, Width:{Width}, Height:{Height}");
        }
    }
}
