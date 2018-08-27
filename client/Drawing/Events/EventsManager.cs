using System.Timers;

namespace LoESoft.Client.Drawing.Events
{
    public static class EventsManager
    {
        public static bool IsEventActive = false;

        public static void SetUnactive()
        {
            Timer timer = new Timer(100);
            timer.Elapsed += StopTimer;
            timer.Enabled = true;

            void StopTimer(object o, ElapsedEventArgs e)
            {
                IsEventActive = false;
                timer.Stop();
            }
        }
    }
}
