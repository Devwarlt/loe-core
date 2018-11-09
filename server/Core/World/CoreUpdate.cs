using System.Threading;

namespace LoESoft.Server.Core.World
{
    public class CoreUpdate
    {
        public WorldMap Map { get; private set; }

        public AutoResetEvent ResetEvent { get; private set; }

        private Thread _updateThread;

        private bool _canpdate = true;

        public CoreUpdate(WorldManager manager)
        {
            Map = new WorldMap(manager);
            ResetEvent = new AutoResetEvent(true);
        }

        public void Initialize()
        {
            _updateThread = new Thread(() =>
            {
                while (_canpdate)
                {
                    Map.Update();
                    ResetEvent.WaitOne();
                }
            });
            _updateThread.IsBackground = true;
            _updateThread.Start();
        }
        
        public void Dispose()
        {
            ResetEvent.Close();
            _canpdate = false;
            Map.Dispose();
        }
    }
}
