using LoESoft.Client.Core.Game.Objects;
using Microsoft.Xna.Framework;

namespace LoESoft.Client.Core.Game
{
    public class Camera
    {
        public const double SCALE = Tile.TILE_SIZE / 1.2;

        public static BasicObject Focus { get; set; }
        public static float X { get; set; }
        public static float Y { get; set; }

        public static void SetFocus(BasicObject focus) => Focus = focus;

        public static Matrix GetMatrix()
        {
            if (Focus == null)
                return Matrix.Identity;

            X = MathHelper.Lerp(X, Focus.DrawX, 1f);
            Y = MathHelper.Lerp(Y, Focus.DrawY, 1f);

            return Matrix.CreateTranslation(-X - 4, -Y - 4, 0) * // -4 is magic number atm until gameobject sprite size has a part
                Matrix.CreateScale((float)SCALE) *
                Matrix.CreateTranslation(GameApplication.WIDTH / 2, GameApplication.HEIGHT / 2, 0);
        }
    }
}