using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.Screens;
using Newtonsoft.Json;
using System.Drawing;

namespace LoESoft.Client.Core.Networking.Packets.Incoming
{
    public class ServerResponse : IncomingPacket
    {
        public string From { get; set; }
        public int Result { get; set; }
        public string Content { get; set; }

        [JsonIgnore]
        public override PacketID PacketID => PacketID.SERVER_RESPONSE;

        // result '-1' -> error
        // result '0' -> success
        public override void Handle(GameUser gameUser)
        {
            App.Info($"({From} [{Result}]) {Content}");

            switch (From)
            {
                case "Login":
                    LoginHandler();
                    break;

                case "Register":
                    RegisterHandler();
                    break;

                case "CreateNewCharacter":
                    CreateNewCharacter();
                    break;

                case "LoadCharacter": // TODO.
                    HandleCharacterLoad();
                    break;

                case "Server.Character.UnlockedCharacters":
                    HandleUnlockedCharacters();
                    break;
            }
        }

        private void LoginHandler()
            => App.Launcher.MainMenu.UpdateGameDialog("Welcome", "Login Denied", Content,
                () =>
                {
                    App.Launcher.MainMenu.SetGameDialog(true);
                    App.Launcher.MainMenu.EnableBox("login");
                },
                () =>
                {
                    App.Launcher.MainMenu.SetGameDialog(false);
                    App.Launcher.MainMenu.OnBoxClose("login", Result == 0);
                },
                Result == 0, ContentAlignment.MiddleCenter);

        private void RegisterHandler()
            => App.Launcher.MainMenu.UpdateGameDialog("Welcome", "Register Denied", Content,
                () =>
                {
                    App.Launcher.MainMenu.SetGameDialog(true);
                    App.Launcher.MainMenu.EnableBox("register");
                },
                () =>
                {
                    App.Launcher.MainMenu.SetGameDialog(false);
                    App.Launcher.MainMenu.OnBoxClose("register", Result == 0);
                },
                Result == 0, ContentAlignment.MiddleCenter);

        public void HandleCharacterLoad()
        {
            if (Result == 0)
            {
                if (ScreenManager.ActiveScreen == GameApplication.CharacterScreen)
                {
                    var content = Content.Split(',');
                    var id = int.Parse(content[0]);
                    var type = int.Parse(content[1]);

                    GameApplication.CharacterScreen.LoadGame(id, type);
                }
            }
            else
                App.Warn("Unable To Load Character");
        }

        public void CreateNewCharacter()
        {
            if (ScreenManager.ActiveScreen == GameApplication.CharacterScreen)
            {
                var content = Content.Split(',');

                GameApplication.CharacterScreen.RefreshCharacterSelection(int.Parse(content[0]), int.Parse(content[1]));
            }
        }

        private void HandleUnlockedCharacters()
        {
            if (ScreenManager.ActiveScreen == GameApplication.CharacterScreen)
                GameApplication.CharacterScreen.AddCharacterSelection(Content);
        }
    }
}