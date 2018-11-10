using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.Screens;
using Newtonsoft.Json;
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
                    LoginHandler();
                    break;

                case "Register":
                    RegisterHandler();
                    break;

                case "CreateNewCharacter": // TODO.
                case "LoadCharacter": // TODO.
                    break;

                case "Server.Character.UnlockedCharacters":
                    HandleUnlockedCharacters();
                    break;
            }
        }

        private void RegisterHandler() => MessageBox.Show(Content, Result == 0 ? "Welcome" : "Register Denied");

        private void LoginHandler()
        {
            App.Launcher.MainMenu.LoggedIn = Result == 0; // temporarily

            MessageBox.Show(Content, Result == 0 ? "Welcome" : "Login Denied");
        }

        private void HandleUnlockedCharacters()
        {
            if (ScreenManager.ActiveScreen == GameApplication.CharacterScreen)
                GameApplication.CharacterScreen.AddCharacterSelection(Content);
        }
    }
}