namespace LoESoft.Client.Drawing
{
    public class RGBColor
    {
        public static RGBColor Default => new RGBColor(255, 255, 255);
        public static RGBColor Empty => new RGBColor(0, 0, 0);

        private int _r;

        public int R
        {
            get => _r;
            set => _r = (value > 255) ? 255 : value;
        }

        private int _g;

        public int G
        {
            get => _g;
            set => _g = (value > 255) ? 255 : value;
        }

        private int _b;

        public int B
        {
            get => _b;
            set => _b = (value > 255) ? 255 : value;
        }

        public RGBColor(int r, int g, int b)
        {
            R = r;
            G = g;
            B = b;
        }
    }
}