using LoESoft.Server.Core.Networking.Packets.Outgoing;
using LoESoft.Server.Core.World.Map.Data;
using LoESoft.Server.Utils;
using System.Collections.Generic;
using System.Linq;

namespace LoESoft.Server.Core.World.Entities.Player
{
    public partial class Player
    {
        private HashSet<Tile> _addedTile = new HashSet<Tile>();
        private HashSet<GameObject> _addedObjects = new HashSet<GameObject>();

        private HashSet<GameObject> _objectsToUpdateOrAdd = new HashSet<GameObject>();
        private HashSet<Tile> _tilesToUpdateOrAdd = new HashSet<Tile>();
        
        private HashSet<int> _removedObjects = new HashSet<int>();

        private int _connectionLostAttempts = 0;
        private readonly int _maxConnectionListAttempts = 10;
        
        public override void Update()
        {
            testConnection();

            Health = LoERandom.Next(0, 100);

            var sight = GetSightPoints().Where(_ => _.X >= 0 && _.X < WorldMap.WIDTH && _.Y >= 0 && _.Y < WorldMap.HEIGHT);
            var chunk = GetChunk();
            
            foreach(var i in chunk.RemovedEntities)
                _removedObjects.Add(i);

            foreach (var i in sight)
            {
                var tile = Manager.Core.Map.Tiles[i.X, i.Y];

                if ((_addedTile.Contains(tile) && tile.UpdateCount > 0) || !_addedTile.Contains(tile))
                    _tilesToUpdateOrAdd.Add(tile);

                if (!_addedTile.Contains(tile))
                    _addedTile.Add(tile);

                tile.OnUpdate();

                var entity = chunk.GetEntity(i.X, i.Y);

                if (entity != null)
                {
                    if ((_addedObjects.Contains(entity) && entity.UpdateCount > 0) || !_addedObjects.Contains(entity))
                        _objectsToUpdateOrAdd.Add(entity);

                    if (!_addedObjects.Contains(entity))
                        _addedObjects.Add(entity);

                    entity.OnUpdate();
                }

                var player = Manager.Core.Map.GetPlayer(i.X, i.Y);

                if (player != null && player.ObjectId != ObjectId)
                {
                    if ((_addedObjects.Contains(player) && player.UpdateCount > 0) || !_addedObjects.Contains(player))
                        _objectsToUpdateOrAdd.Add(player);

                    if (!_addedObjects.Contains(player))
                        _addedObjects.Add(player);

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

        private void testConnection()
        {
            if (!Client.IsConnected)
            {
                _connectionLostAttempts++;

                App.Info($"[Attempt {_connectionLostAttempts}/{_maxConnectionListAttempts}] Client {Client.Id} dropped connection, retrying...");

                if (_connectionLostAttempts == _maxConnectionListAttempts)
                {
                    Client.Disconnect();
                    return;
                }

                return;
            }
            else
                _connectionLostAttempts = 0;
        }
    }
}