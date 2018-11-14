using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.GUI.MainScreen;
using LoESoft.Client.Core.Screens;
using LoESoft.Client.Core.Screens.TitleScreen;
using Newtonsoft.Json;
using System.Linq;
using System.Windows.Forms;

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
                    LoginHandler(gameUser);
                    break;

                case "Register":
                    RegisterHandler(gameUser);
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

        public void HandleCharacterLoad()
        {
            App.Warn($"{int.Parse(Content)}");
            if (Result == 0)
                CharacterSettings.CurrentCharacterType = int.Parse(Content);
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

        private void RegisterHandler(GameUser gameUser)
        {
            if (Result == 0)
                App.ToggleLauncherElement(From);
            else
                MessageBox.Show("Register Denied");
        }

        private void LoginHandler(GameUser gameUser)
        {
            if (Result == 0)
                App.ToggleLauncherElement(From);
            else
                MessageBox.Show("Login Denied");
        }

        private void HandleUnlockedCharacters()
        {
            if (ScreenManager.ActiveScreen == GameApplication.CharacterScreen)
                GameApplication.CharacterScreen.AddCharacterSelection(Content);
        }
    }
}