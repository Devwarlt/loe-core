﻿using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.Screens;
using Newtonsoft.Json;

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
            switch (From)
            {
                case "Login": // TODO.
                    LoginHandler();
                    break;

                case "Register": // TODO.
                case "CreateNewCharacter": // TODO.
                case "LoadCharacter": // TODO.
                    App.Info($"({From} [{Result}]) {Content}");
                    break;
                case "Server.Character.UnlockedCharacters":
                    HandleUnlockedCharacters();
                    break;
                default:
                    App.Info($"New server response detected!\n{ToString()}");
                    break;
            }
        }

        private void HandleUnlockedCharacters()
        {
            if (ScreenManager.ActiveScreen == GameApplication.CharacterScreen)
                GameApplication.CharacterScreen.AddCharacterSelection(Content);
        }

        private void LoginHandler()
        {
            App.Launcher.MainMenu.LoggedIn = Result == 0; // temporarily

            //App.Launcher.MainMenu.UpdateSettings(new PopUpSettings()
            //{
            //    Title = Result == 0 ? "Welcome" : "Login Denied",
            //    Content = Content,
            //    Alignment = ContentAlignment.MiddleCenter,
            //    OnDisplay = () =>
            //    {
            //        App.Launcher.MainMenu.LoggedIn = Result == 0;
            //        App.Launcher.MainMenu.SetPopUpBoxVisibility(true);
            //        App.Launcher.MainMenu.ToggleLoginBox();
            //    },
            //    OnClose = () =>
            //    {
            //        App.Launcher.MainMenu.SetPopUpBoxVisibility(false);
            //        App.Launcher.MainMenu.OnLoginBoxClose(Result == 0);
            //    }
            //});

            App.Info($"({From} [{Result}]) {Content}");
        }
    }
}