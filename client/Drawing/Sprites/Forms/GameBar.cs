using LoESoft.Client.Assets;

namespace LoESoft.Client.Drawing.Sprites.Forms
{
    public class GameBar : Sprite
    {
        public GameBar(int x, int y, int width, int height, RGBColor color = null, float alpha = 1) 
            : base(x, y, width, height, AssetLibrary.Images["panelImage"], color, alpha)
        {
        }
    }
}
