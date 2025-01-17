﻿using LoESoft.Server.Core.Networking;
using System.Collections.Concurrent;

namespace LoESoft.Server.Core.World
{
    public class WorldManager
    {
        public ConcurrentDictionary<int, NetworkClient> Clients = new ConcurrentDictionary<int, NetworkClient>();

        private GameClock _clock { get; set; }

        public CoreUpdate Core { get; set; }

        public WorldManager()
        {
            Core = new CoreUpdate(this);

            _clock = new GameClock(() => Core.Set());
        }

        public void BeginUpdate()
        {
            Core.Initialize();
            _clock.Start();
        }

        public bool TryAddPlayer(NetworkClient client, out string error)
        {
            error = "";
            if (Clients.Count >= WorldSettings.MAX_CONNECTIONS)
            {
                error = "Server is currently full!";
                return false;
            }

            if (client.Player != null)
            {
                Clients.TryAdd(client.ClientId, client);

                return true;
            }

            error = "Unable to load player!";

            return false;
        }

        public bool TryRemovePlayer(NetworkClient client)
        {
            if (Clients.Values.Contains(client))
            {
                if (Clients.TryRemove(client.ClientId, out var outclient))
                    Core.Map.Remove(outclient.Player);

                return true;
            }

            return false;
        }

        public void Stop()
        {
            foreach (var i in Clients)
                i.Value.Disconnect();

            Clients.Clear();

            _clock.Stop();

            Core.Dispose();
        }
    }
}