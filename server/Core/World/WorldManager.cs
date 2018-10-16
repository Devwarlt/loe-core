using LoESoft.Server.Core.Networking;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;

namespace LoESoft.Server.Core.World
{
    public class WorldManager
    {
        public MapData Map { get; set; }
        public ConcurrentBag<Client> Clients { get; set; }

        public WorldManager()
        {
            Map = new MapData(this);
            Clients = new ConcurrentBag<Client>();
        }

        public void BeginUpdate()
        {
            var tickUpdate =
                new Thread(() =>
                {
                    do
                    {
                        Map.Update();

                        Thread.Sleep(WorldSettings.COOLDOWN);
                    } while (true);
                })
                { IsBackground = true };
            tickUpdate.Start();
        }

        public void Stop()
        {
            foreach (var i in Clients)
                i?.Disconnect();
        }

        public bool TryAddPlayer(Client client)
        {
            if (Clients.Count >= WorldSettings.MAX_CONNECTIONS)
                return false;

            if (client.Player != null)
            {
                GameServer.Info("Player added!");

                Map.AddPlayer(client.Player);

                return true;
            }

            return false;
        }

        public bool TryRemovePlayer(Client client)
        {
            if (Clients.Contains(client))
            {
                GameServer.Info("Player removed!");

                Clients.TryTake(out client);

                Map.RemovePlayer(client.Player);

                return true;
            }

            return false;
        }
    }
}