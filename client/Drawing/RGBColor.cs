using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoESoft.Client.Drawing
{
    public class RGBColor
    {
        int _r;
        public int R
        {
            get { return _r; }
            set
            {
                _r = (value > 225) ? 225 : value;
            }
        }
        int _g;
        public int G
        {
            get { return _g; }
            set
            {
                _g = (value > 225) ? 225 : value;
            }
        }
        int _b;
        public int B
        {
            get { return _b; }
            set
            {
                _b = (value > 225) ? 225 : value;
            }
        }

        public RGBColor(int r, int g, int b)
        {
            _r = r;
            _g = g;
            _b = b;
        }

        public static RGBColor Default
        {
            get { return new RGBColor(135, 135, 135); }
        }
    }
}
