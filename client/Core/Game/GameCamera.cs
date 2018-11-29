using LoESoft.Client.Core.Game.Objects;
using Microsoft.Xna.Framework;

namespace LoESoft.Client.Core.Game
{
    public class GameCamera
    {
        public const float SCALE = 8;

        public GameObject Focus { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public void Update(GameObject focus)
        {
            Focus = focus;
        }
        
        public Matrix GetMatrix()
        {
            if (Focus == null)
                return Matrix.Identity;

            X = (int)Focus.DrawX;
            Y = (int)Focus.DrawY;
            var size = Focus.Size;

            return
                Matrix.CreateTranslation(-(X + (size / 2)), -(Y + (size / 2)), 0) *
                Matrix.CreateScale(SCALE) *
                Matrix.CreateTranslation(GameApplication.WIDTH / 2, GameApplication.HEIGHT / 2, 0);
        }
    }
}