using LoESoft.Client.Core.Models;
using LoESoft.Client.Core.Networking.Packets.Outgoing;
using LoESoft.Client.Core.Screens;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Drawing;

namespace LoESoft.Client.Core.Networking.Packets.Incoming
{
    public class ServerResponse : IncomingPacket
    {
        public string From { get; set; }
        public int Result { get; set; }
        public string Content { get; set; }
        
        public override PacketID PacketID => PacketID.SERVER_RESPONSE;

        public override void Read(NetworkReader reader)
        {
            From = reader.ReadUTF();
            Result = reader.ReadInt32();
            Content = reader.ReadUTF();
        }

        public override void Handle()
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

                case "LoadCharacter":
                    HandleCharacterLoad();
                    break;

                case "UnlockedCharacters":
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
            var loading = new ConcurrentQueue<Action>();

            switch(Result)
            {
                case 0:
                    {
                        var content = JsonConvert.DeserializeObject<PlayerInfo>(Content);

                        loading.Enqueue(delegate
                        {
                            NetworkClient.SendPacket(new Load() { });
                        });

                        App.Warn("Managing Screen!");

                        ScreenManager.DispatchScreen(new LoadingScreen(loading,
                            GameApplication.GameScreen = new GameScreen(content)));
                    } break;
                case -1:
                    {
                        //Error notification
                        //Error end
                        ScreenManager.DispatchScreen(GameApplication.CharacterScreen);
                    } break;
            }
        }

        public void CreateNewCharacter()
        {
            if (ScreenManager.ActiveScreen == GameApplication.CharacterScreen)
            {
                var content = Content.Split(',');

                GameApplication.CharacterScreen.RefreshCharacterSelection(int.Parse(content[0]), int.Parse(content[1]));
            }
            else
            {
                App.Warn(Content);
            }
        }

        private void HandleUnlockedCharacters()
        {
            if (ScreenManager.ActiveScreen == GameApplication.CharacterScreen)
                GameApplication.CharacterScreen.AddCharacterSelection(Content);
        }
    }
}