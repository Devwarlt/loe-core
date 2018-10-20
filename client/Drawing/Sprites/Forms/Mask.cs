namespace LoESoft.Client.Drawing.Sprites.Forms
{
    public class Mask : FilledRectangle
    {
        public Mask(RGBColor color, float alpha = 0.5f)
            : base(0, 0, 800, 600, color, alpha) => IsZeroApplicaple = true;
    }
}