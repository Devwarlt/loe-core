using LoESoft.Client.Assets;
using LoESoft.Client.Drawing.Sprites.Forms;
using System.Collections.Generic;
using System.Linq;

namespace LoESoft.Client.Core.Screens.TitleScreen.CharacterSelection
{
    public class CharacterSelectHUD : FilledRectangle
    {
        private Dictionary<int, CharacterRect> _classView;

        private List<int> _classIds = new List<int>()
        { 5 };

        public CharacterSelectHUD(int x, int y)
            : base(x, y, 400, 200, new Drawing.RGBColor(225, 35, 35), 0.75f)
        {
            _classView = new Dictionary<int, CharacterRect>();

            int rx = 0;
            foreach (var i in XmlLibrary.ObjectsXml.Where(_ => _classIds.Contains(_.Key)))
            {
                _classView.Add(i.Key, new CharacterRect(i.Value, rx, 5));
                rx += 40 + 3;
            }
        }

        public void Init()
        {

        }



    }
}
