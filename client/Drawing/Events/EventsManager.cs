using System.Timers;

namespace LoESoft.Client.Drawing.Events
{
    public static class EventsManager
    {
        public static ActiveSpriteNode ActiveNode;

        static EventsManager()
        {
            ActiveNode = new ActiveSpriteNode()
            {
                IsActive = false,
                Node = null
            };
        }

        public static void SetUnactive()
        {
            var timer = new Timer(5);
            timer.Elapsed += StopTimer;
            timer.Enabled = true;

            void StopTimer(object o, ElapsedEventArgs e)
            {
                ActiveNode.IsActive = false;
                ActiveNode.Node = null;
                timer.Stop();
            }
        }
    }
}
