using LoESoft.Client.Assets;
using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Sprites.Forms;
using LoESoft.Client.Drawing.Sprites.Text;
using System.Collections.Generic;

namespace LoESoft.Client.Core.Screens.TitleScreen.CharacterSelection
{
    public class CharacterSelectHUD : FilledRectangle
    {
        public static int MAXCHARACTERS = 3;

        private List<CharacterRect> _classView;

        private List<int> _unlockedClasses;

        private TextDisplay _chooseACharacter;

        public CharacterSelectHUD(int x, int y)
            : base(x, y, 800, 400, new RGBColor(25, 35, 125), alpha: 0.4f)
        {
            _classView = new List<CharacterRect>();
            _unlockedClasses = new List<int>();
        }

        public void Init(string result)
        {
            _chooseACharacter = new TextDisplay(20, 5, "Choose A Character", 24, new RGBColor(75, 225, 125));
            _chooseACharacter.Outline = true;

            string[] results = result.Split(',');

            for (var i = 0; i < MAXCHARACTERS; i++)
            {
                int idx = int.Parse(results[i]);
                int x = i * 250 + 15;
                var character = new CharacterRect(x, 60);

                if (idx != -1)
                    character.Init(XmlLibrary.ObjectsXml[idx]);

                _classView.Add(character);
                AddChild(character);
            }
            
            AddChild(_chooseACharacter);
        }
    }
}
