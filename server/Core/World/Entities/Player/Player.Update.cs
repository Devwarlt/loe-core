using LoESoft.Server.Core.Networking.Packets.Outgoing;
using LoESoft.Server.Core.World.Map.Data;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace LoESoft.Server.Core.World.Entities.Player
{
    public partial class Player
    {
        private List<Entity> _addedObjects = new List<Entity>();
        private List<Entity> _objectsToUpdateOrAdd = new List<Entity>();
        
        private List<Tile> _addedTile = new List<Tile>();
        private List<Tile> _tilesToUpdateOrAdd = new List<Tile>();

        //unused atm
        private List<Tile> _removedTiles = new List<Tile>();
        private List<Entity> _removedObjects = new List<Entity>();

        public override void Update()
        {
            var sight = GetSightPoints().Where(_ => ((_.X >= 0 && _.X < WorldMap.WIDTH) &&
            (_.Y >= 0 && _.Y < WorldMap.HEIGHT)));

            foreach (var i in sight)
            {
                var tile = Manager.Map.Tiles[i.X , i.Y];

                if ((_addedTile.Contains(tile) && tile.UpdateCount > 0) || !_addedTile.Contains(tile))
                    _tilesToUpdateOrAdd.Add(tile);

                if (!_addedTile.Contains(tile))
                    _addedTile.Add(tile);

                Manager.Map.Tiles[i.X + X, i.Y + Y].UpdateCount = 0;
            }

            //foreach(var i in Manager.Map.GetValidChunkToArea(sight.ToArray()))
            //{
            //    foreach(var e in i.Entities.Where(_ => sight.Contains(new Points(_.X, _.Y))))
            //    {
            //        if ((_addedObjects.Contains(e) && e.UpdateCount > 0) || !_addedObjects.Contains(e))
            //            _objectsToUpdateOrAdd.Add(e);

            //        if (!_addedObjects.Contains(e))
            //            _addedObjects.Add(e);

            //        e.UpdateCount = 0;
            //    }
            //}
            
            Client.SendPacket(new Update()
            {
                AddOrUpdateTile = _tilesToUpdateOrAdd.Select( _ => TileData.GetData(_)).ToArray(),
                AddOrUpdateObject = _objectsToUpdateOrAdd.Select(_ => ObjectData.GetData(_)).ToArray()
            });

            _tilesToUpdateOrAdd.Clear();
            _objectsToUpdateOrAdd.Clear();
        }
    }
}
