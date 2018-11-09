using LoESoft.Client.Core.Client;
using Newtonsoft.Json;

namespace LoESoft.Client.Core.Networking.Packets.Incoming
{
    public class Response : IncomingPacket
    {
        public string From { get; set; }
        public int Result { get; set; }
        public string Content { get; set; }

        [JsonIgnore]
        public override PacketID PacketID => PacketID.RESPONSE;

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

                default:
                    App.Info($"New server response detected!\n{ToString()}");
                    break;
            }
        }

        private void LoginHandler()
        {
            GameApplication.TitleScreen._logged = Result == 0;

            App.Info($"({From} [{Result}]) {Content}");
        }
    }
}