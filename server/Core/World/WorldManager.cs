using LoESoft.Server.Core.Networking;
using System.Threading;

namespace LoESoft.Server.Core.World
{
    public class WorldManager
    {
        public WorldMap Map { get; set; }

        public bool CanUpdate = true;

        private GameClock _clock { get; set; }

        private Thread UpdateThread { get; set; }

        public WorldManager()
        {
            Map = new WorldMap(this);

            _clock = new GameClock(() => Map.Update());
        }

        public void BeginUpdate() => _clock.Start();

        public bool TryAddPlayer(Client client)
        {
            if (ConnectionListener.Clients.Count >= WorldSettings.MAX_CONNECTIONS)
                return false;

            if (client.Player != null)
            {
                Map.Add(client.Player);

                return true;
            }

            return false;
        }

        public bool TryRemovePlayer(Client client)
        {
            if (ConnectionListener.Clients.Values.Contains(client))
            {
                if (client.Player != null)
                {
                    Map.Remove(client.Player);
                    App.Warn("Player removed!");
                }

                return true;
            }

            return false;
        }

        public void Stop()
        {
            _clock.Stop();

            Map.Dispose();
        }
    }
}