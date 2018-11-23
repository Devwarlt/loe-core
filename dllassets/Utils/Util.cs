using System;

namespace LoESoft.Dlls.Utils
{
    public partial class Util
    {
        private readonly Action<string> _log;

        private void Logger(string message) => _log?.Invoke(message);

        public Util() : this(null)
        {
        }

        public Util(Action<string> log) => _log = log;
    }
}