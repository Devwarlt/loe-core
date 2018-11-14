using System;
using System.Timers;

namespace LoESoft.Client.Core.GUI.MainScreen
{
    public class InternalClock
    {
        public Timer Timer { get; set; }

        public InternalClock(int internalMs, Action action)
        {
            Timer = new Timer(internalMs) { AutoReset = true };
            Timer.Elapsed += delegate
            {
                action?.Invoke();
            };
        }

        public void Start() => Timer.Start();

        public void Stop() => Timer.Stop();
    }
}