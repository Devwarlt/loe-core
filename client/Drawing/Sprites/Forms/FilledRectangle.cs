using LoESoft.Client.Assets;
using Microsoft.Xna.Framework.Graphics;

namespace LoESoft.Client.Drawing.Sprites.Forms
{
    public class FilledRectangle : Sprite
    {
        public FilledRectangle(Texture2D texture2D)
            : base(0, 0, GameApplication.WIDTH, GameApplication.HEIGHT, texture2D) { }

        public FilledRectangle(int x, int y, int width, int height, RGBColor color = null, float alpha = 1)
            : base(x, y, width, height, AssetLibrary.Images["rectImage"], color, alpha) { }
    }
}