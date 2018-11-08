using LoESoft.Server.Core.Networking.Packets.Outgoing;
using LoESoft.Server.Core.World.Map.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public override void Update()
        {
            var timer = new Stopwatch();
            timer.Start();

            var sight = GetSightPoints().Where(_ => ((_.X >= 0 && _.X < WorldMap.WIDTH) &&
            (_.Y >= 0 && _.Y < WorldMap.HEIGHT)));

            foreach (var i in sight)
            {
                var tile = Manager.Map.Tiles[i.X , i.Y];

                if ((_addedTile.Contains(tile) && tile.UpdateCount > 0) || !_addedTile.Contains(tile))
                    _tilesToUpdateOrAdd.Add(tile);

                if (!_addedTile.Contains(tile))
                    _addedTile.Add(tile);

                tile.UpdateCount = 0;

                var entity = Manager.Map.Chunks[new Tuple<int, int>(ChunkX, ChunkY)].GetEntity(i.X, i.Y);

                if (entity != null)
                {
                    if ((_addedObjects.Contains(entity) && entity.UpdateCount > 0) || !_addedObjects.Contains(entity))
                        _objectsToUpdateOrAdd.Add(entity);

                    if (!_addedObjects.Contains(entity))
                        _addedObjects.Add(entity);
                    
                    entity.UpdateCount = 0;
                }

                var player = Manager.Map.GetPlayer(i.X, i.Y);

                if (player != null && player.ObjectId != ObjectId)
                {
                    if ((_addedObjects.Contains(player) && player.UpdateCount > 0) || !_addedObjects.Contains(player))
                        _objectsToUpdateOrAdd.Add(player);

                    if (!_addedObjects.Contains(player))
                        _addedObjects.Add(player);

                    player.UpdateCount = 0;
                }
            }
            
            if (_tilesToUpdateOrAdd.Count > 0 || _objectsToUpdateOrAdd.Count > 0)
                Client.SendPacket(new Update()
                {
                    AddOrUpdateTile = _tilesToUpdateOrAdd.Select( _ => TileData.GetData(_)).ToArray(),
                    AddOrUpdateObject = _objectsToUpdateOrAdd.Select(_ => ObjectData.GetData(_)).ToArray()
                });
            
            _tilesToUpdateOrAdd.Clear();
            _objectsToUpdateOrAdd.Clear();
            
            App.Warn("Took Server " + timer.ElapsedMilliseconds.ToString() + "MS to update!");

            timer.Stop();
        }
    }
}
