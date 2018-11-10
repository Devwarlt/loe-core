using LoESoft.Client.Assets;
using LoESoft.Client.Drawing.Sprites.Forms;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace LoESoft.Client.Core.Screens.TitleScreen.CharacterSelection
{
    public class CharacterSelectHUD : FilledRectangle
    {
        public static int MAXCHARACTERS = 3;

        private List<CharacterRect> _classView;

        private List<int> _unlockedClasses;

        public CharacterSelectHUD(int x, int y)
            : base(x, y, 400, 200, alpha: 0.75f)
        {
            _classView = new List<CharacterRect>();
            _unlockedClasses = new List<int>();

            SpriteColor = Color.Black;
        }

        public void Init(string result)
        {
            string[] results = result.Split(',');

            for (var i = 0; i < MAXCHARACTERS; i++)
            {
                int idx = int.Parse(results[i]);
                var character = new CharacterRect(i * 40 + 5, 5);

                if (idx != -1)
                    character.Init(XmlLibrary.ObjectsXml[idx]);

                _classView.Add(character);
                AddChild(character);
            }
        }
    }
}
