using LoESoft.Server.Core.Networking;
using LoESoft.Server.Core.World.Entities.Player;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace LoESoft.Server.Core.World
{
    public static class WorldManager
    {
        public static MapData Map { get; private set; }

        public static ConcurrentBag<Client> Clients = new ConcurrentBag<Client>();

        public static void Initialize()
        {
            Map = new MapData();

            loopThread = new Thread(() =>
            {
                do
                {
                    Map.Update();

                    Thread.Sleep(WorldSettings.COOLDOWN);

                } while (true);
            });

            loopThread.Priority = ThreadPriority.Highest;
        }

        static Thread loopThread;
        public static void TickUpdate()
        {
            loopThread.Start();
        }

        public static void Stop()
        {
            foreach (var i in Clients)
                i.Disconnect();
        }

        public static bool TryAddPlayer(Client client)
        {
            if (Clients.Count >= WorldSettings.MAXPLAYERS)
                return false;

            Clients.Add(client);

            Map.AddPlayer(client.Player);

            GameServer.Warn("Player added!");

            return true;
        }

        public static void TryRemovePlayer(Client client)
        {
            if (Clients.Contains(client))
            {
                Clients.TryTake(out client);
                Map.RemovePlayer(client.Player);
            }
        }
    }
}
