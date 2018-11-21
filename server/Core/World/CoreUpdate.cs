
using LoESoft.Server.Utils;
using System.Diagnostics;
using System.Threading;

namespace LoESoft.Server.Core.World
{
    public class CoreUpdate
    {
        public WorldMap Map { get; private set; }

        public AutoResetEvent ResetEvent { get; private set; }

        private WorldTime _worldTime;
        private Stopwatch _watch;
        private WorldManager _manager;
        private Thread _updateThread;

        private bool _canpdate = true;

        public CoreUpdate(WorldManager manager)
        {
            _watch = new Stopwatch();
            _worldTime = new WorldTime();
            ResetEvent = new AutoResetEvent(true);
            _manager = manager;
        }

        public void Initialize()
        {
            Map = new WorldMap(_manager);

            _updateThread = new Thread(() =>
            {
                int tickCount = 0;

                while (_canpdate)
                {
                    _worldTime.TotalElapsedMs = _watch.Elapsed.Milliseconds;
                    _worldTime.TickCount = tickCount;

                    Map.Update(_worldTime);
                    
                    ResetEvent.WaitOne();
                    tickCount++;
                }
            });
            _updateThread.IsBackground = true;

            _updateThread.Start();
            _watch.Start();
        }

        public void Set() => ResetEvent.Set();
        
        public void Dispose()
        {
            _watch.Stop();
            ResetEvent.Close();
            _canpdate = false;
            Map.Dispose();
        }
    }
}