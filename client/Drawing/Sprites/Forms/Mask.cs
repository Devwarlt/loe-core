using System;

namespace LoESoft.Client.Drawing.Sprites.Forms
{
    public class Mask : FilledRectangle
    {
<<<<<<< HEAD
=======
        private Action maskClicked;

        public event Action OnMaskClicked
        {
            add { maskClicked += value; }
            remove { maskClicked -= value; }
        }

>>>>>>> 51b17f14330b81c0c30302632c2cf2a05e7bebda
        public Mask(RGBColor color, float alpha = 0.5f) :
            base(0, 0, 800, 600, color, alpha)
        {
            IsZeroApplicaple = true;
<<<<<<< HEAD
=======

            AddEventListener(Events.Event.CLICKLEFT, delegate { maskClicked?.Invoke(); });
>>>>>>> 51b17f14330b81c0c30302632c2cf2a05e7bebda
        }
    }
}