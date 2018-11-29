using LoESoft.Client.Core.Game.Objects;
using Microsoft.Xna.Framework;

namespace LoESoft.Client.Core.Game
{
    public class Camera
    {
        public const float SCALE = 8;

        public GameObject Focus { get; set; }

        public float X { get; set; }
        public float Y { get; set; }

        public void SetFocus(GameObject focus)
        {
            Focus = focus;
        }
        
        public Matrix GetMatrix()
        {
            X = Focus.DrawX;
            Y = Focus.DrawY;

            return Matrix.Identity *
                Matrix.CreateTranslation(-X - (Focus.Size / 2), -Y - (Focus.Size / 2), 0) *
                Matrix.CreateTranslation(GameApplication.WIDTH / 2, GameApplication.HEIGHT / 2, 0) *
                Matrix.CreateScale(SCALE);
        }
    }
}