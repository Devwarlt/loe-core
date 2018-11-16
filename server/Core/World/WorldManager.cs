using LoESoft.Server.Core.Networking;

namespace LoESoft.Server.Core.World
{
    public class WorldManager
    {
        private GameClock _clock { get; set; }

        public CoreUpdate Core { get; set; }

        public WorldManager()
        {
            Core = new CoreUpdate(this);

            _clock = new GameClock(() => Core.ResetEvent.Set());
        }

        public void BeginUpdate()
        {
            Core.Initialize();
            _clock.Start();
        }

        public bool TryAddPlayer(Client client)
        {
            if (ConnectionListener.Clients.Count >= WorldSettings.MAX_CONNECTIONS)
                return false;

            if (client.Player != null)
            {
                Core.Map.Add(client.Player);

                return true;
            }

            return false;
        }

        public bool TryRemovePlayer(Client client)
        {
            if (ConnectionListener.Clients.Values.Contains(client))
            {
                if (client.Player != null)
                    Core.Map.Remove(client.Player);

                return true;
            }

            return false;
        }

        public void Stop()
        {
            _clock.Stop();

            Core.Dispose();
        }
    }
}