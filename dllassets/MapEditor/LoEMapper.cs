using System;
using System.IO;

namespace LoESoft.Dlls.MapEditor
{
    public partial class LoEMapper<Map>
    {
        public const string FileFormatCompressed = "lscmap";
        public const string FileFormatNonCompressed = "lsmap";

        public string MainDir { get; }
        public string BaseDir { get; }

        public bool EnableCompression { get; set; }

        private string _format { get => EnableCompression ? FileFormatCompressed : FileFormatNonCompressed; }

        private readonly Action<string> _log;

        private void Logger(string message) => _log?.Invoke(message);

        public LoEMapper(string basedir) : this(basedir, false, null)
        {
        }

        public LoEMapper(string basedir, Action<string> log) : this(basedir, false, log)
        {
        }

        public LoEMapper(string basedir, bool enableCompression) : this(basedir, enableCompression, null)
        {
        }

        public LoEMapper(string basedir, bool enableCompression, Action<string> log)
        {
            MainDir = Path.GetPathRoot(Environment.SystemDirectory);
            BaseDir = Path.Combine(MainDir, basedir);
            EnableCompression = enableCompression;

            _log = log;
        }
    }
}