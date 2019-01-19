namespace LoESoft.Client.Core.Networking.Packets.Outgoing
{
    public class Login : OutgoingPacket
    {
        public string Email { get; set; }
        public string Password { get; set; }
        
        public override PacketID PacketID => PacketID.LOGIN;

        public override void Write(NetworkWriter writer)
        {
            writer.WriteUTF(Email);
            writer.WriteUTF(Password);
        }
    }
}