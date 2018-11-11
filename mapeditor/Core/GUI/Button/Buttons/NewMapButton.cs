using LoESoft.MapEditor.Core.GUI.Forms;
using LoESoft.MapEditor.Core.Layer;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Windows.Forms;

namespace LoESoft.MapEditor.Core.GUI.Button.Buttons
{
    public class NewMapButton : EditorButton
    {
        public NewMapButton(Texture2D texture, Vector2 position) : base(texture, position)
        {
        }

        public override void Effect()
        {
            MapEditor.MapState = MapState.Inactive;

            var newmap = new NewMapForm();
            newmap.ShowDialog();

            if (newmap.DialogResult == DialogResult.OK)
            {
                MapEditor.Map = new Map(newmap.MapWidth, newmap.MapHeight);
                MapEditor.CurrentLayer = 0;
                MapEditor.CurrentIndex = 0;
                MapEditor.DrawOffset = Vector2.Zero;
                MapEditor.MapName = newmap.MapName;

                foreach (var mapsprite in MapEditor.MapSprites)
                    MapEditor.Map.LoadTileSet(mapsprite.Key, mapsprite.Value);

                PreviousClicked = false;
            }
            else
                PreviousClicked = false;

            MapEditor.MapState = MapState.Active;

            base.Effect();
        }
    }
}