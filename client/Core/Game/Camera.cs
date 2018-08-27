using LoESoft.Client.Core.Game.Objects;
using Microsoft.Xna.Framework;

namespace LoESoft.Client.Core.Game
{
    public class Camera
    {
        public const int SCALE = Tile.TILE_SIZE / 2;

        public static BasicObject Focus { get; set; }
        public static float X { get; set; }
        public static float Y { get; set; }
        public static void SetFocus(BasicObject focus) => Focus = focus;

        public static Matrix GetMatrix()
        {
            if (Focus == null)
                return Matrix.Identity;

            X = MathHelper.Lerp(X, Focus.DrawX, 0.25f);
            Y = MathHelper.Lerp(Y, Focus.DrawY, 0.25f);

            return Matrix.CreateTranslation(-X - 4, -Y - 4, 0) *
            Matrix.CreateScale(SCALE) *
            Matrix.CreateTranslation(GameApplication.WIDTH / 2, GameApplication.HEIGHT / 2, 0);
        }
    }
}
