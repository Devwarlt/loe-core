using System;
using System.Timers;

namespace LoESoft.Server.Core.World
{
    public class GameClock
    {
        public Timer Timer { get; set; }

        public GameClock(Action action)
        {
            Timer = new Timer(WorldSettings.UPDATE_MS) { AutoReset = true };
            Timer.Elapsed += delegate
            {
                action?.Invoke();
            };
        }

        public void Start() => Timer.Start();

        public void Stop() => Timer.Stop();
    }
}