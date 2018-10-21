using LoESoft.Client.Core.Client;
using Newtonsoft.Json;
using System.Text;

namespace LoESoft.Client.Core.Networking.Packets.Incoming
{
    public class Response : IncomingPacket
    {
        public string From { get; set; }
        public int Result { get; set; }
        public string Content { get; set; }

        [JsonIgnore]
        public override PacketID PacketID => PacketID.RESPONSE;

        // TODO: result '-1' display a popup with content / result '0' display a popup and let player login.
        public override void Handle(GameUser gameUser)
        {
            switch (From)
            {
                case "Login": LoginHandler(); break; // TODO.
                case "Register": RegisterHandler(); break; // TODO.
                case "CreateNewCharacter": CreateNewCharacterHandler(); break; // TODO.
                case "LoadCharacter": LoadCharacterHandler(); break; // TODO.
                default: GameClient.Info($"New server response detected!\n{ToString()}"); break;
            }
        }

        private void LoginHandler()
        {
        }

        private void RegisterHandler()
        {
        }

        private void CreateNewCharacterHandler()
        {
        }

        private void LoadCharacterHandler()
        {
        }

        public override string ToString()
        {
            var ret = new StringBuilder("{\n");

            for (var i = 0; i < GetType().GetProperties().Length; i++)
            {
                if (i != 0)
                    ret.Append(",\n");

                ret.AppendFormat("\t{0}: {1}", GetType().GetProperties()[i].Name, GetType().GetProperties()[i].GetValue(this, null));
            }

            ret.Append("\n}");

            return ret.ToString();
        }
    }
}