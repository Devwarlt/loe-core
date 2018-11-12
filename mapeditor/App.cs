using LoESoft.MapEditor.Properties;
using NLog;
using NLog.Config;
using NLog.Targets;
using Rollbar;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

namespace LoESoft.MapEditor
{
    public static class App
    {
        // Font Cache DLL
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbfont, uint cbfont, IntPtr pdv, [In] ref uint pcFonts);

        // Embedded Font
        public static FontFamily DisposableDroidBB;

        // Assembly's Data
        public static string Name => Assembly.GetExecutingAssembly().GetName().Name;

        public static string Version =>
            $"{Assembly.GetExecutingAssembly().GetName().Version}".Substring(0,
            $"{Assembly.GetExecutingAssembly().GetName().Version}".Length - 2);

        // Log
        private static Logger Log => LogManager.GetLogger(Name);

        // Unique IDs
        private static string RollbarId => "ca02c5d9fb834c33880af31a6407fa18";

        [STAThread]
        public static void Main()
        {
            Console.Title = $"{Name} - Build: {Version}";

            var config = new LoggingConfiguration();
            var developerLog = new ColoredConsoleTarget()
            {
                Name = "developer",
                Layout = @"[${date:format=HH\:mm\:ss}] [${level}] ${message} ${exception}"
            };
            var developerFile = new FileTarget()
            {
                Name = "developer-file",
                FileName = "../../../../../logs/client/Build ${assembly-version}/${level}/${date:format=dd-MM-yyyy HH.mm.ss}.txt",
                Layout = @"[${date:format=HH\:mm\:ss}] [${level}] ${message} ${exception}"
            };
            config.AddTarget(developerLog);
            config.AddTarget(developerFile);
            config.AddRule(LogLevel.Info, LogLevel.Fatal, developerFile);
            config.AddRuleForAllLevels(developerLog);

            LogManager.Configuration = config;

            RollbarLocator.RollbarInstance.Configure(new RollbarConfig(RollbarId));

            Info("Game Map Editor is loading...");

            try
            {
                LoadEmbeddedFonts();

                using (var mapeditor = new MapEditor())
                    mapeditor.Run();
            }
            catch (Exception e)
            {
                Info("An error occurred!");

                Error(e);

                Thread.Sleep(100);

                Warn("Press 'ESC' to close...");

                while (Console.ReadKey(true).Key != ConsoleKey.Escape)
                    ;

                Environment.Exit(0);
            }
        }

        public static void Info(string data) => Log.Info(data);

        public static void Warn(string data) => Log.Warn(data);

        public static void Error(Exception e, string data = null)
        {
            Log.Error($"{data}{(data == null ? "" : "\n")}{e.ToString()}");

#if DEBUG
            // Rollbar error analytics for developers only.
            RollbarLocator.RollbarInstance.Error(e);
#endif
        }

        private static void LoadEmbeddedFonts()
        {
            var buffer = Resources.DisposableDroidBB;
            var len = buffer.Length;
            var data = Marshal.AllocCoTaskMem(len);

            Marshal.Copy(buffer, 0, data, len);

            uint pcFonts = 0;

            AddFontMemResourceEx(data, (uint)buffer.Length, IntPtr.Zero, ref pcFonts);

            var fontcollection = new PrivateFontCollection();
            fontcollection.AddMemoryFont(data, len);

            Marshal.FreeCoTaskMem(data);

            DisposableDroidBB = fontcollection.Families[0];
        }
    }
}