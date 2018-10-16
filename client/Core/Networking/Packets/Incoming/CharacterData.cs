using LoESoft.Client.Core.Client;
using Newtonsoft.Json;

namespace LoESoft.Client.Core.Networking.Packets.Incoming
{
    public class CharacterData : IncomingPacket
    {
        public string Character { get; set; }

        public override PacketID PacketID => PacketID.CHARACTER_DATA;

        public override void Handle(GameUser gameUser)
        {
            var character = JsonConvert.DeserializeObject(Character); // get character data
        }
    }
}