namespace LoESoft.Launcher
{
    public class GameLauncherParameters
    {
        /// <summary>
        /// This is the Web Server DNS used to request and connect user's account to get game data.
        ///
        /// <example>
        /// <para>Example:</para>
        /// <para>http://testing.loesoft.org/</para>
        /// </example>
        /// </summary>
        public static readonly string SERVER = "http://127.0.0.1:7172"; // feel free to change port

        /// <summary>
        /// This is the current version of Launcher used to display as readonly text.
        /// </summary>
        public static readonly string LAUNCHER_VERSION = $"Version: {GameLauncher._version}";
    }
}