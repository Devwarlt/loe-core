using System;

namespace LoESoft.Dlls.MapEditor
{
    public partial class LoEMapper<Map>
    {
        public string MainDir { get; }
        public bool EnableCompression { get; }

        private string _format { get; }

        private readonly Action<string> _log;
        private readonly string _fileFormatCompressed = "lscmap";
        private readonly string _fileFormatNonCompressed = "lsmap";

        private void Logger(string message) => _log?.Invoke(message);

        public LoEMapper(string basedir) : this(basedir, false, null)
        {
        }

        public LoEMapper(string basedir, bool enableCompression) : this(basedir, enableCompression, null)
        {
        }

        public LoEMapper(string basedir, bool enableCompression, Action<string> log)
        {
            MainDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            EnableCompression = enableCompression;

            _log = log;
            _format = EnableCompression ? _fileFormatCompressed : _fileFormatNonCompressed;
        }
    }
}
