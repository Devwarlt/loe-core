#if DEBUG

using NLog;
using NLog.Config;
using NLog.Targets;
using Rollbar;
using System.IO;
using System.Runtime.InteropServices;

#endif

using LoESoft.AssetsManager.Core.GUI;
using System;
using System.Reflection;
using System.Windows.Forms;
using System.Threading;

namespace LoESoft.AssetsManager
{
    public static class App
    {
        // Assembly's Data
        public static string Name => Assembly.GetExecutingAssembly().GetName().Name;

        public static string Version =>
            $"{Assembly.GetExecutingAssembly().GetName().Version}".Substring(0,
            $"{Assembly.GetExecutingAssembly().GetName().Version}".Length - 2);

#if DEBUG
        private const UInt32 StdOutputHandle = 0xFFFFFFF5;

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetStdHandle(UInt32 nStdHandle);

        [DllImport("kernel32.dll")]
        private static extern void SetStdHandle(UInt32 nStdHandle, IntPtr handle);

        [DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        // Log
        private static Logger Log => LogManager.GetLogger(Name);

        // Unique IDs
        private static string RollbarId => "ca02c5d9fb834c33880af31a6407fa18";

#endif

        [STAThread]
        private static void Main()
        {
#if DEBUG
            AllocConsole();

            var defaultStdout = new IntPtr(7);

            if (GetStdHandle(StdOutputHandle) != defaultStdout)
                SetStdHandle(StdOutputHandle, defaultStdout);

            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
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
                FileName = "../../../logs/assetsmanager/Build ${assembly-version}/${level}/${date:format=dd-MM-yyyy HH.mm.ss}.txt",
                Layout = @"[${date:format=HH\:mm\:ss}] [${level}] ${message} ${exception}"
            };
            config.AddTarget(developerLog);
            config.AddTarget(developerFile);
            config.AddRule(LogLevel.Info, LogLevel.Fatal, developerFile);
            config.AddRuleForAllLevels(developerLog);

            LogManager.Configuration = config;

            RollbarLocator.RollbarInstance.Configure(new RollbarConfig(RollbarId));
#endif

            Info("Game Xml Manager is loading...");

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Manager());
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

#if DEBUG

        public static void Info(string data) => Log.Info(data);

        public static void Warn(string data) => Log.Warn(data);

        public static void Error(Exception e, string data = null)
        {
            Log.Error($"{data}{(data == null ? "" : "\n")}{e.ToString()}");

            RollbarLocator.RollbarInstance.Error(e); // Rollbar error analytics for developers only.
        }

#else

        public static void Info(string data)
        {
        }

        public static void Warn(string data)
        {
        }

        public static void Error(Exception e, string data = null)
        {
        }

#endif
    }
}