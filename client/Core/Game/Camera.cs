using LoESoft.Client.Core.Game.Objects;
using Microsoft.Xna.Framework;
using System;

namespace LoESoft.Client.Core.Game
{
    public static class Camera
    {
        public const double SCALE = Tile.TILE_SIZE;

        public static Entity Focus { get; set; }

        public static float X { get; set; }
        public static float Y { get; set; }

        private static int _rotationIncrement = 0;

        public static void RotateRight() => _rotationIncrement++;

        public static void RotateLeft() => _rotationIncrement--;

        public static void SetFocus(Entity focus) => Focus = focus;

        public static Vector2 CameraToWorldPosition(int x, int y) => Vector2.Transform(new Vector2(x, y), GetMatrix());

        public static Matrix GetMatrix()
        {
            if (Focus == null)
                return Matrix.Identity;

            X = MathHelper.Lerp(X, Focus.DrawX, 1f);
            Y = MathHelper.Lerp(Y, Focus.DrawY, 1f);

            return Matrix.CreateTranslation(-X - (Focus.Size / 2), -Y - (Focus.Size / 2), 0) *
                Matrix.CreateScale((float)SCALE) *
                Matrix.CreateRotationZ(_rotationIncrement * (float)(Math.PI / 2)) *
                Matrix.CreateTranslation(GameApplication.WIDTH / 2, GameApplication.HEIGHT / 2, 0);
        }
    }
}