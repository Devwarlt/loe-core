using LoESoft.Server.Core.Networking;
using System.Threading;

namespace LoESoft.Server.Core.World
{
    public class WorldManager
    {
        public MapData Map { get; set; }

        public WorldManager() => Map = new MapData(this);

        public void BeginUpdate()
            => new Thread(() =>
            {
                do
                {
                    Map.Update();

                    Thread.Sleep(WorldSettings.COOLDOWN);
                } while (true);
            })
            { IsBackground = true }.Start();

        public bool TryAddPlayer(Client client)
        {
            if (ConnectionListener.Clients.Count >= WorldSettings.MAX_CONNECTIONS)
                return false;

            if (client.Player != null)
            {
                App.Info("Player added!");

                Map.AddPlayer(client.Player);

                return true;
            }

            return false;
        }

        public bool TryRemovePlayer(Client client)
        {
            if (ConnectionListener.Clients.Values.Contains(client))
            {
                App.Info("Player removed!");

                if (client.Player != null)
                    Map.RemovePlayer(client.Player);

                return true;
            }

            return false;
        }
    }
}