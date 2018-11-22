using LoESoft.Client.Drawing.Sprites.Forms;

namespace LoESoft.Client.Core.Game.User.GUI.UI.Elements
{
    public class InventoryView : FilledRectangle
    {
        public ItemCell[] Items { get; set; }

        private int _globalX = 5;
        private int _globalY = 5;
        
        public InventoryView(int x, int y) 
            : base(x, y, 445, 225, new Drawing.RGBColor(255, 255, 255))
        {
            Items = new ItemCell[32];

            for(var i = 0; i < Items.Length; i++)
            {
                Items[i] = new ItemCell(_globalX, _globalY);
                var newX = _globalX + 55;

                if (newX < 400)
                    _globalX = newX;
                else
                {
                    _globalX = 5;
                    _globalY = _globalY + 55;
                }

                AddChild(Items[i]);
            }
        }

        public void SetItem(int idx, int id) => Items[idx].Init(id);
    }
}
