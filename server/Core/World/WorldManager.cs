using LoESoft.Server.Core.Networking;
using LoESoft.Server.Core.World.Entities.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoESoft.Server.Core.World
{
    public static class WorldManager
    {
        public static MapData Map { get; private set; }

        public static Dictionary<Client, Player> Players = new Dictionary<Client, Player>();

        static WorldManager()
        {
            Map = new MapData();
            Players = new Dictionary<Client, Player>();
        }

        public static void TryAddPlayer(Client client)
        {
            if (Players.Count >= WorldSettings.MAXPLAYERS)
                return;

            Players.Add(client, client.Player);
        }

        public static void TryRemovePlayer(Client client)
        {
            if (Players.Keys.Contains(client))
                Players.Remove(client);
        }
    }
}
