using LoESoft.Server.Core.Networking;
using LoESoft.Server.Core.World.Entities.Player;
using System.Collections.Generic;
using System.Linq;

namespace LoESoft.Server.Core.World
{
    public static class WorldManager
    {
        public static MapData Map { get; private set; }

        public static Dictionary<Client, Player> Players = new Dictionary<Client, Player>(); //Useless atm

        static WorldManager()
        {
            Map = new MapData();
            Players = new Dictionary<Client, Player>();
        }

        public static bool TryAddPlayer(Client client)
        {
            if (Players.Count >= WorldSettings.MAXPLAYERS)
                return false;

            Players.Add(client, client.Player);
            GameServer.Warn($"{client.Player.X} Was added");
            return true;
        }

        public static void TryRemovePlayer(Client client)
        {
            if (Players.Keys.Contains(client))
                Players.Remove(client);

            GameServer.Warn($"{client.Player.X} Was removed");
        }
    }
}
