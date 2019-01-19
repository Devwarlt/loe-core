namespace LoESoft.Client.Core.Networking.Packets.Outgoing
{
    public class Register : OutgoingPacket
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        
        public override PacketID PacketID => PacketID.REGISTER;

        public override void Write(NetworkWriter writer)
        {
            writer.WriteUTF(Email);
            writer.WriteUTF(Name);
            writer.WriteUTF(Password);
            writer.WriteUTF(ConfirmPassword);
        }
    }
}