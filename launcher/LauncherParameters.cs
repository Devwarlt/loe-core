using System.Reflection;

namespace LoESoft.Launcher
{
    public class LauncherParameters
    {
        public static readonly string SERVER = "http://127.0.0.1:7172"; // feel free to change port
        public static readonly string LAUNCHER_VERSION = $"Version: {Assembly.GetExecutingAssembly().GetName().Version}";
    }
}
