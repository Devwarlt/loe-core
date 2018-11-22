using System;

namespace LoESoft.Dlls.Database
{
    public partial class LoEDb
    {
        public string MainDir { get; }
        public string BaseDir { get; }

        private readonly Action<string> _log;

        private void Logger(string message) => _log?.Invoke(message);

        public LoEDb(string basedir, Action<string> log)
        {
            MainDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            BaseDir = basedir;

            _log = log;
        }
    }
}