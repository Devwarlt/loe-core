namespace LoESoft.Client.Core.Networking.Packets.Outgoing
{
    public class CreateNewCharacter : OutgoingPacket
    {
        public int World { get; set; }
        public int ClassType { get; set; }
        public int CharacterIndex { get; set; }
        
        public override PacketID PacketID => PacketID.CREATE_NEW_CHARACTER;

        public override void Write(NetworkWriter writer)
        {
            writer.Write(World);
            writer.Write(ClassType);
            writer.Write(CharacterIndex);
        }
    }
}