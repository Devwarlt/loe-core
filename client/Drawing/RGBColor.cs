namespace LoESoft.Client.Drawing
{
    public class RGBColor
    {
        int _r;
        public int R
        {
            get { return _r; }
            set { _r = (value > 255) ? 255 : value; }
        }
        int _g;
        public int G
        {
            get { return _g; }
            set { _g = (value > 255) ? 255 : value; }
        }
        int _b;
        public int B
        {
            get { return _b; }
            set { _b = (value > 255) ? 255 : value; }
        }

        public RGBColor(int r, int g, int b)
        {
            R = r;
            G = g;
            B = b;
        }

        public static RGBColor Default() => new RGBColor(255, 255, 255);
    }
}
