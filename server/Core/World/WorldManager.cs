using LoESoft.Server.Core.Networking;
using System.Diagnostics;
using System.Threading;

namespace LoESoft.Server.Core.World
{
    public class WorldManager
    {
        public WorldMap Map { get; set; }

        public bool CanUpdate = true;

        private Thread UpdateThread { get; set; }

        public WorldManager() => Map = new WorldMap(this);

        public void BeginUpdate()
        {
            UpdateThread = new Thread(() =>
            {
                var time = new GameTime();
                var timer = new Stopwatch();

                int looptime = 0;

                timer.Start();

                while (CanUpdate)
                {
                    time.TotalElapsedMs = timer.ElapsedMilliseconds;
                    time.TickDelta = looptime / WorldSettings.COOLDOWN;
                    time.ElaspedMsDelta = WorldSettings.COOLDOWN * time.TickDelta;

                    if (time.TickDelta > 3)
                        App.Warn("LAGGED!");

                    Map.Update(time);

                    Thread.Sleep(WorldSettings.COOLDOWN);
                    looptime += (int)(timer.ElapsedMilliseconds - time.TotalElapsedMs) - time.ElaspedMsDelta;
                }
            })
            { IsBackground = true };

            UpdateThread.Start();
        }
            

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
                if (client != null)
                    Map.Remove(client.Player);

                return true;
            }

            return false;
        }

        public void Stop()
        {
            CanUpdate = false;
            Map.Dispose();
        }
    }
}