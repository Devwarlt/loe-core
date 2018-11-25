using LoESoft.Client.Core.Game.Map;
using LoESoft.Client.Drawing.Sprites.Forms;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;

namespace LoESoft.Client.Core.Game.User.GUI.UI
{
    public class MiniMap : FilledRectangle
    {
        public MiniMap(int x, int y)
            : base(x, y, 300, 300, new Drawing.RGBColor(0, 0, 0), 0.75f)
        {
            IsZeroApplicaple = true;
        }

        public void ReloadMap(int x, int y)
        {
        }

        private static Texture2D[] getTiles(int x, int y) => WorldMap.GetTilesInSight(x, y).Select(_ => _.Texture).ToArray();

        private static Texture2D[] getEntities(int x, int y) => WorldMap.GetEntitiesInSight(x, y).Select(_ => _.Texture).ToArray();
    }
}