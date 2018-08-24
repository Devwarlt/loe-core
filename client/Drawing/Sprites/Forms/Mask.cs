using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LoESoft.Client.Drawing.Sprites.Forms
{
    public class Mask : FilledRectangle
    {
        private Action maskClicked;
        public event Action OnMaskClicked
        {
            add { maskClicked += value; }
            remove { maskClicked -= value; }
        }

        public Mask(RGBColor color, float alpha = 0.5f) :
            base(0, 0, 600, 600, color, alpha)
        {
            IsZeroApplicaple = true;

            AddEventListener(Events.Event.CLICKLEFT, onMaskClicked);
        }

        private void onMaskClicked(object sender, EventArgs e)
        {
            maskClicked?.Invoke();
        }
    }
}
