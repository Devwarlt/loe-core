using LoESoft.Client.Core.Game.Objects;
using Microsoft.Xna.Framework;

namespace LoESoft.Client.Core.Game
{
    public class GameCamera
    {
        public const float SCALE = 6.5f;

        public GameObject Focus { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public void Update(GameObject focus)
        {
            Focus = focus;
        }

        public Vector2 ScreenToWorld(Vector2 location) => Vector2.Transform(location, Matrix.Invert(GetMatrix()));
        public Vector2 WorldToScreen(Vector2 location) => Vector2.Transform(location, GetMatrix());

        public Matrix GetMatrix()
        {
            if (Focus == null)
                return Matrix.Identity;

            X = (int)Focus.DrawX;
            Y = (int)Focus.DrawY;

            return
                Matrix.CreateTranslation(-(X + 4), -(Y + 4), 0) *
                Matrix.CreateScale(SCALE) *
                Matrix.CreateTranslation(GameApplication.WIDTH / 2, GameApplication.HEIGHT / 2, 0);
        }
    }
}