using LoESoft.Server.Core.Networking;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;

namespace LoESoft.Server.Core.World
{
    public class WorldManager
    {
        public MapData Map { get; private set; }

        public ConcurrentBag<Client> Clients = new ConcurrentBag<Client>();

        public void Initialize()
        {
            Map = new MapData(this);

            loopThread = new Thread(() =>
            {
                do
                {
                    Map.Update();

                    Thread.Sleep(WorldSettings.COOLDOWN);

                } while (true);
            });
        }

        static Thread loopThread;
        public void TickUpdate()
        {
            loopThread.Start();
        }

        public void Stop()
        {
            foreach (var i in Clients)
                i.Disconnect();
        }

        public bool TryAddPlayer(Client client)
        {
            if (Clients.Count >= WorldSettings.MAXPLAYERS)
                return false;

            Clients.Add(client);

            Map.AddPlayer(client.Player);

            GameServer.Warn("Player added!");

            return true;
        }

        public void TryRemovePlayer(Client client)
        {
            if (Clients.Contains(client))
            {
                Clients.TryTake(out client);
                Map.RemovePlayer(client.Player);
            }
        }
    }
}
