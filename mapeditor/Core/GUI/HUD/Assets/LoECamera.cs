using Microsoft.Xna.Framework;

namespace LoESoft.MapEditor.Core.GUI.HUD.Assets
{
    public  class LoECamera
    {
        public Vector2 Bounds { get; set; }
        public Vector2 Position { get; set; }
        public float Zoom { get; set; }

        public LoECamera(int width, int height)
        {
            Bounds = new Vector2(width, height);
            Position = Vector2.Zero;
            Zoom = 1f;
        }

        public void ZoomIn(float val) => Zoom += val;
        public void ZoomOut(float val) => Zoom -= val;
        public void SetZoom(float val) => Zoom = val;
        public void SetZoomToPosition(float val, Vector2 pos)
        {
            var currentMouseTarget = Zoom * pos;
            var nextMouseTarget = pos * val;

            Position += (nextMouseTarget - currentMouseTarget) / val;

            Zoom = val;
        }

        public void SetFocus(Vector2 pos) => Position = pos;
        
        public Vector2 ScreenToWorld(Vector2 location) => Vector2.Transform(location, Matrix.Invert(GetViewMatrix()));
        public Vector2 WorldToScreen(Vector2 location) => Vector2.Transform(location, GetViewMatrix());

        public Matrix GetViewMatrix()
        {
            return Matrix.CreateTranslation(-Position.X, -Position.Y, 0) * 
                Matrix.CreateScale(Zoom);
        }
    }
}
