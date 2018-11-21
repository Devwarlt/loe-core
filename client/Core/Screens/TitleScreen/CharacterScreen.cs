using LoESoft.Client.Assets;
using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.Game;
using LoESoft.Client.Core.Networking.Packets.Outgoing;
using LoESoft.Client.Core.Screens.TitleScreen;
using LoESoft.Client.Core.Screens.TitleScreen.CharacterSelection;
using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Events;
using LoESoft.Client.Drawing.Sprites.Forms;
using LoESoft.Client.Drawing.Sprites.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace LoESoft.Client.Core.Screens
{
    public class CharacterScreen : Screen
    {
        public List<Tile> Tiles { get; set; }

        private float TitleFlashSpeedR = 0;

        private TextDisplay Title { get; set; }
        private TextButton PlayButton { get; set; }
        private TextButton ExitButton { get; set; }
        private FilledRectangle Background { get; set; }

        private CharacterSelectHUD CharacterSelect { get; set; }

        private GameUser _gameUser;

        public CharacterScreen(GameUser gameUser)
        {
            _gameUser = gameUser;
        }

        private void OnPlayButtonOver(object sender, EventArgs e) => PlayButton.TextDisplay.SpriteColor = Color.Yellow;

        private void OnPlayButtonOut(object sender, EventArgs e) => PlayButton.TextDisplay.SpriteColor = Color.White;

        private void OnExitButtonOver(object sender, EventArgs e) => ExitButton.TextDisplay.SpriteColor = Color.Yellow;

        private void OnExitButtonOut(object sender, EventArgs e) => ExitButton.TextDisplay.SpriteColor = Color.White;

        private void OnPlay(object sender, EventArgs e)
        {
            if (CharacterSettings.CurrentCharacterId != -1)
                _gameUser.SendPacket(new Load() { CharacterIndex = CharacterSettings.CurrentCharacterId });
        }

        public void LoadGame(int objectId, int classType)
        {
            var loading = new ConcurrentQueue<Action>();

            ScreenManager.DispatchScreen(new LoadingScreen(loading,
                GameApplication.GameScreen = new GameScreen(_gameUser, objectId, classType)));
        }

        private void OnExit(object sender, EventArgs e) => ScreenManager.Close();

        public override void OnScreenCreate()
        {
            Title = new TextDisplay(0, 0, "BRME", 30, new RGBColor(255, 0, 0));
            Title.X = DrawHelper.CenteredToScreenWidth(Title.Width);
            Title.Y = 20;
            Title.Outline = true;

            PlayButton = new TextButton("Play", 30);
            PlayButton.X = DrawHelper.CenteredToScreenWidth(PlayButton.Width);
            PlayButton.Y = DrawHelper.CenteredToScreenHeight(PlayButton.Height);
            PlayButton.Y = 700;
            PlayButton.TextDisplay.Outline = true;
            PlayButton.AddEventListener(Event.CLICKLEFT, OnPlay);
            PlayButton.AddEventListener(Event.MOUSEOVER, OnPlayButtonOver);
            PlayButton.AddEventListener(Event.MOUSEOUT, OnPlayButtonOut);

            Background = new FilledRectangle(AssetLibrary.Images["titleScreenBackGround"])
            {
                X = 0,
                Y = 0
            };

            Background.AddChild(Title);
            Background.AddChild(PlayButton);

            _gameUser.SendPacket(new ClientResponse()
            {
                From = "Client.Character.GetUnlockedCharacters",
                Result = 0,
                Content = ""
            });
        }

        public void AddCharacterSelection(string response)
        {
            CharacterSelect = new CharacterSelectHUD(DrawHelper.CenteredToScreenWidth(720), 400);
            CharacterSelect.Init(_gameUser, response);

            Background.AddChild(CharacterSelect);
        }

        public void RefreshCharacterSelection(int index, int type) => CharacterSelect.ReloadView(index, type);

        public override void OnScreenDispatch()
        {
        }

        public override void Update(GameTime gameTime)
        {
            TitleFlashSpeedR += 1.0f / gameTime.ElapsedGameTime.Milliseconds * 0.5f;

            Title.SpriteColor = Color.Lerp(Color.Red, Color.Yellow, (float)Math.Sin(TitleFlashSpeedR));

            Background.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            Background.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}