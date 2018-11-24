namespace LoESoft.Server.Core.World.Entities.Interfaces
{
    public class Comparable
    {
        public int ObjectId { get; set; }

        public override bool Equals(object obj) => ObjectId == ((Comparable)obj).ObjectId;

        public override int GetHashCode() => 34855695 + ObjectId.GetHashCode();
    }
}
