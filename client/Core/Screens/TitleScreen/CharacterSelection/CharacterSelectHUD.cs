using LoESoft.Client.Assets;
using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Sprites.Forms;
using LoESoft.Client.Drawing.Sprites.Text;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LoESoft.Client.Core.Screens.TitleScreen.CharacterSelection
{
    class UnlockedCharacterData
    {
        public int[] UnlockedClassTypes { get; set; }
    }
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

            var data = JsonConvert.DeserializeObject<UnlockedCharacterData>(result);

            for (var i = 0; i < MAXCHARACTERS; i++)
            {
                int idx = data.UnlockedClassTypes[i];
                int x = i * 250 + 15;
                var character = new CharacterRect(x, 60);
                
                character.Init(idx);

                _classView.Add(character);
                AddChild(character);
            }

            AddChild(_chooseACharacter);
        }
    }
}
