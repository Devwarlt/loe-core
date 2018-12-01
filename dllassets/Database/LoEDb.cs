using System;
using System.Collections.Generic;
using System.IO;

namespace LoESoft.Dlls.Database
{
    public partial class LoEDb
    {
        public const string FileFormatCompressed = "lscdat";
        public const string FileFormatNonCompressed = "lsdat";

        public string MainDir { get; }
        public string BaseDir { get; }

        public List<string> SubFolders { get; private set; }

        public string Format => EnableCompression ? FileFormatCompressed : FileFormatNonCompressed;

        public bool EnableCompression { get; set; }

        private readonly Action<string> _log;

        private void Logger(string message) => _log?.Invoke(message);

        public LoEDb(string basedir) : this(basedir, false, null)
        {
        }

        public LoEDb(string basedir, Action<string> log) : this(basedir, false, log)
        {
        }

        public LoEDb(string basedir, bool enableCompression) : this(basedir, enableCompression, null)
        {
        }

        public LoEDb(string basedir, bool enableCompression, Action<string> log)
        {
            MainDir = Path.GetPathRoot(Environment.SystemDirectory);
            BaseDir = Path.Combine(MainDir, basedir);
            SubFolders = new List<string>();
            EnableCompression = enableCompression;

            _log = log;
        }
    }
}