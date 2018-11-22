using LoESoft.Server.Core.Networking.Packets.Outgoing;
using LoESoft.Server.Core.World.Map.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoESoft.Server.Core.World.Entities.Player
{
    public partial class Player
    {
        private List<Tile> _addedTile = new List<Tile>();
        private List<Entity> _addedObjects = new List<Entity>();

        private List<Entity> _objectsToUpdateOrAdd = new List<Entity>();
        private List<Tile> _tilesToUpdateOrAdd = new List<Tile>();

        //unused atm
        private List<Entity> _removedObjects = new List<Entity>();

        private int ConnectionLostAttempts = 0;
        private readonly int MaxConnectionListAttempts = 10;

        public override void Update()
        {
            if (!Client.IsConnected)
            {
                ConnectionLostAttempts++;

                App.Info($"[Attempt {ConnectionLostAttempts}/{MaxConnectionListAttempts}] Client {Client.Id} dropped connection, retrying...");

                if (ConnectionLostAttempts == MaxConnectionListAttempts)
                {
                    Client.Disconnect();
                    return;
                }

                return;
            }
            else
                ConnectionLostAttempts = 0;

            var sight = GetSightPoints().Where(_ => ((_.X >= 0 && _.X < WorldMap.WIDTH) && (_.Y >= 0 && _.Y < WorldMap.HEIGHT)));

            foreach (var i in sight)
            {
                var tile = Manager.Core.Map.Tiles[i.X, i.Y];

                if ((_addedTile.Contains(tile) && tile.UpdateCount > 0) || !_addedTile.Contains(tile))
                    _tilesToUpdateOrAdd.Add(tile);

                if (!_addedTile.Contains(tile))
                    _addedTile.Add(tile);

                tile.OnUpdate();

                var entity = Manager.Core.Map.Chunks[new Tuple<int, int>(ChunkX, ChunkY)].GetEntity(i.X, i.Y);

                if (entity != null)
                {
                    if ((_addedObjects.Contains(entity) && entity.UpdateCount > 0) || !_addedObjects.Contains(entity))
                        _objectsToUpdateOrAdd.Add(entity);

                    if (!_addedObjects.Contains(entity))
                        _addedObjects.Add(entity);

                    entity.OnUpdate();
                }

                var player = Manager.Core.Map.GetPlayer(i.X, i.Y);

                if (player != null)
                {
                    if ((_addedObjects.Contains(player) && player.UpdateCount > 0) || !_addedObjects.Contains(player))
                        _objectsToUpdateOrAdd.Add(player);

                    if (!_addedObjects.Contains(player))
                        _addedObjects.Add(player);

                    player.OnUpdate();
                }
            }

            if (_tilesToUpdateOrAdd.Count > 0 || _objectsToUpdateOrAdd.Count > 0)
                Client.SendPacket(new Update()
                {
                    AddOrUpdateTile = _tilesToUpdateOrAdd.Select(_ => TileData.GetData(_)).ToArray(),
                    AddOrUpdateObject = _objectsToUpdateOrAdd.Select(_ => ObjectData.GetData(_)).ToArray()
                });

            _tilesToUpdateOrAdd.Clear();
            _objectsToUpdateOrAdd.Clear();
        }
    }
}