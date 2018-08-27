using LoESoft.Client.Core.Game.Objects;
using Microsoft.Xna.Framework;

namespace LoESoft.Client.Core.Game
{
    public class Camera
    {
        public const int SCALE = Tile.TILE_SIZE / 2;

        public static BasicObject Focus { get; set; }

        public static void SetFocus(BasicObject focus) => Focus = focus;

        public static Matrix GetMatrix() => Matrix.CreateScale(SCALE); // todo implement center focus
    }
}
