using LoESoft.Server.Core.Networking.Data;
using LoESoft.Server.Core.Networking.Packets.Outgoing;
using System.Collections.Generic;
using System.Linq;

namespace LoESoft.Server.Core.World.Entities.Player
{
    public partial class Player
    {
        private HashSet<int> _addedTile = new HashSet<int>();
        private HashSet<int> _addedObjects = new HashSet<int>();

        private HashSet<GameObject> _objectsToUpdateOrAdd = new HashSet<GameObject>();
        private HashSet<Tile> _tilesToUpdateOrAdd = new HashSet<Tile>();
        
        private HashSet<int> _removedObjects = new HashSet<int>();
        
        public override void Update()
        {
            var sight = GetSightPoints().Where(_ => _.X >= 0 && _.X < WorldMap.WIDTH && _.Y >= 0 && _.Y < WorldMap.HEIGHT);
            var chunk = GetChunk();
            
            foreach(var i in chunk.RemovedEntities)
                _removedObjects.Add(i);

            foreach (var i in sight)
            {
                var tile = Manager.Core.Map.Tiles[i.X, i.Y];

                if ((_addedTile.Contains(tile.ObjectId) && tile.UpdateCount > 0) 
                    || !_addedTile.Contains(tile.ObjectId))
                    _tilesToUpdateOrAdd.Add(tile);

                if (!_addedTile.Contains(tile.ObjectId))
                    _addedTile.Add(tile.ObjectId);

                tile.OnUpdate();

                var entity = chunk.GetEntity(i.X, i.Y);

                if (entity != null)
                {
                    if ((_addedObjects.Contains(entity.ObjectId) && entity.UpdateCount > 0) 
                        || !_addedObjects.Contains(entity.ObjectId))
                        _objectsToUpdateOrAdd.Add(entity);

                    if (!_addedObjects.Contains(entity.ObjectId))
                        _addedObjects.Add(entity.ObjectId);

                    entity.OnUpdate();
                }

                var player = Manager.Core.Map.GetPlayer(i.X, i.Y);

                if (player != null && player.ObjectId != ObjectId)
                {
                    if ((_addedObjects.Contains(player.ObjectId) && player.UpdateCount > 0) 
                        || !_addedObjects.Contains(player.ObjectId))
                        _objectsToUpdateOrAdd.Add(player);

                    if (!_addedObjects.Contains(player.ObjectId))
                        _addedObjects.Add(player.ObjectId);

                    player.OnUpdate();
                }
            }

            sendGamePlayerUpdate();
            sendAndClear();
        }

        private void sendGamePlayerUpdate()
        {
            if (UpdateCount > 0)
                Client.SendPacket(new GamePlayerUpdate()
                {
                    Id = Id,
                    ObjectId = ObjectId,
                    Stats = ExportStat()
                });
        }

        private void sendAndClear()
        {
            if (_tilesToUpdateOrAdd.Count > 0 || _objectsToUpdateOrAdd.Count > 0)
                Client.SendPacket(new Update()
                {
                    AddOrUpdateTile = _tilesToUpdateOrAdd.Select(_ => TileData.GetData(_)).ToArray(),
                    AddOrUpdateObject = _objectsToUpdateOrAdd.Select(_ => ObjectData.GetData(_)).ToArray(),
                    RemovedObjects = _removedObjects.ToArray()
                });

            _tilesToUpdateOrAdd.Clear();
            _objectsToUpdateOrAdd.Clear();
            _removedObjects.Clear();
        }
    }
}