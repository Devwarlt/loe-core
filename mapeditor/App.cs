#if DEBUG

using NLog;
using NLog.Config;
using NLog.Targets;
using Rollbar;
using System.IO;

#endif

using LoESoft.MapEditor.Core.GUI;
using LoESoft.MapEditor.Core.GUI.HUD;
using LoESoft.MapEditor.Properties;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

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

#if DEBUG
        private const UInt32 StdOutputHandle = 0xFFFFFFF5;

        //[DllImport("kernel32.dll")]
        //private static extern IntPtr GetStdHandle(UInt32 nStdHandle);

        //[DllImport("kernel32.dll")]
        //private static extern void SetStdHandle(UInt32 nStdHandle, IntPtr handle);

        //[DllImport("kernel32.dll")]
        //private static extern bool AllocConsole();

        // Log
        private static Logger Log => LogManager.GetLogger(Name);

        // Unique IDs
        private static string RollbarId => "ca02c5d9fb834c33880af31a6407fa18";

#endif

        // Map Editor Form
        public static MapEditorForm MapEditor { get; set; }

        // Map Editor Game Control
        public static MEGameControl MapControl { get; set; }

        [STAThread]
        public static void Main(string[] args)
        {
#if DEBUG
            //AllocConsole();

            var defaultStdout = new IntPtr(7);

            //if (GetStdHandle(StdOutputHandle) != defaultStdout)
            //    SetStdHandle(StdOutputHandle, defaultStdout);

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
                FileName = "../../../../../logs/mapeditor/Build ${assembly-version}/${level}/${date:format=dd-MM-yyyy HH.mm.ss}.txt",
                Layout = @"[${date:format=HH\:mm\:ss}] [${level}] ${message} ${exception}"
            };
            config.AddTarget(developerLog);
            config.AddTarget(developerFile);
            config.AddRule(LogLevel.Info, LogLevel.Fatal, developerFile);
            config.AddRuleForAllLevels(developerLog);

            LogManager.Configuration = config;

            RollbarLocator.RollbarInstance.Configure(new RollbarConfig(RollbarId));
#endif
            Info("Game Map Editor is loading...");

            try
            {
                LoadEmbeddedFonts();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(MapEditor = new MapEditorForm());
            }
            catch (Exception e)
            {
                Info("An error occurred!");

                Error(e);

                Thread.Sleep(100);

                Warn("Press 'ESC' to close...");
#if DEBUG
                while (Console.ReadKey(true).Key != ConsoleKey.Escape)
                    ;
#endif

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

        public static void Error(Exception e, string data = null) => MessageBox.Show("An error occurred, report to LoESoft Games developers:\n\n", "Error!");

#endif

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