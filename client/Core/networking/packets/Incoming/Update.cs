using LoESoft.Client.Core.Game.Map;
using LoESoft.Client.Core.Game.Map.Data;

namespace LoESoft.Client.Core.Networking.Packets.Incoming
{
    public class Update : IncomingPacket
    {
        public TileData[] AddOrUpdateTile { get; set; }
        public ObjectData[] AddOrUpdateObject { get; set; }
        public int[] RemovedObjects { get; set; }

        public override PacketID PacketID => PacketID.UPDATE;

        public override void Read(NetworkReader reader)
        {
            int tileCount = reader.ReadInt32();

            AddOrUpdateTile = new TileData[tileCount];
            for (var i = 0; i < tileCount; i++)
            {
                AddOrUpdateTile[i] = new TileData();
                AddOrUpdateTile[i].Read(reader);
            }

            int objectCount = reader.ReadInt32();

            AddOrUpdateObject = new ObjectData[objectCount];
            for (var i = 0; i < objectCount; i++)
            {
                AddOrUpdateObject[i] = new ObjectData();
                AddOrUpdateObject[i].Read(reader);
            }
                
            int removeCount = reader.ReadInt32();

            RemovedObjects = new int[removeCount];
            for (var i = 0; i < removeCount; i++)
                RemovedObjects[i] = reader.ReadInt32();
        }

        public override void Handle() => 
            WorldMap.AddOrUpdate(AddOrUpdateTile, AddOrUpdateObject, RemovedObjects);
    }
}