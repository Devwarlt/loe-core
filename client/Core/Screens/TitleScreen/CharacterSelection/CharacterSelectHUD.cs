using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Sprites.Forms;
using LoESoft.Client.Drawing.Sprites.Text;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LoESoft.Client.Core.Screens.TitleScreen.CharacterSelection
{
    internal class UnlockedCharacterData
    {
        public int[] UnlockedClassTypes { get; set; }
    }

    public class CharacterSelectHUD : FilledRectangle
    {
        private List<CharacterRect> _classView;
        private List<int> _unlockedClasses;
        private TextDisplay _chooseACharacter;

        public CharacterSelectHUD(int x, int y)
            : base(x, y, 720, 200, new RGBColor(0, 0, 0), alpha: 0f)
        {
            _classView = new List<CharacterRect>();
            _unlockedClasses = new List<int>();
        }

        public void Init(string result)
        {
            _chooseACharacter = new TextDisplay(20, 0, "Choose a character", 24, new RGBColor(105, 225, 125));
            _chooseACharacter.Outline = true;

            App.Warn(result);

            var data = JsonConvert.DeserializeObject<UnlockedCharacterData>(result);

            for (var i = 0; i < CharacterSettings.MaxCharacter; i++)
            {
                int idx = data.UnlockedClassTypes[i];
                int x = (i * 250) + (15 * i) + 5;
                var character = new CharacterRect(x, 20);

                character.Init(idx, i);

                _classView.Add(character);
                AddChild(character);
            }

            AddChild(_chooseACharacter);
        }

        public void Unselect(int index)
        {
            foreach (var i in _classView)
                if (i.CharacterIndex != index)
                    i.Selected = false;
        }

        public void ReloadView(int index, int classType)
        {
            _classView[index].Init(classType, index);
        }
    }
}