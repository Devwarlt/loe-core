using LoESoft.Launcher.Misc;
using System.IO;

namespace LoESoft.Launcher
{
    public class Settings
    {
        private static string SettingsConfig => "settings.ini";
        public static Settings LauncherSettings { get; set; }
        public string AutoLogin { get; set; }
        public string AutoUpdate { get; set; }
        public string AutoOffers { get; set; }
        public string AutoNews { get; set; }

        public static Settings LoadSettings()
        {
            LauncherSettings = new Settings();

            var iniFile = new IniFile(SettingsConfig);

            if (!File.Exists(iniFile.Path))
            {
                File.Create(iniFile.Path).Dispose();
                return LauncherSettings;
            }

            LauncherSettings.AutoLogin = iniFile.Read("Auto-Login");
            LauncherSettings.AutoUpdate = iniFile.Read("Auto-Update");
            LauncherSettings.AutoOffers = iniFile.Read("Auto-Offers");
            LauncherSettings.AutoNews = iniFile.Read("Auto-News");

            return LauncherSettings;
        }

        public void SaveSettings()
        {
            var iniFile = new IniFile(SettingsConfig);

            if (LauncherSettings == null) // no longer needed
            {
                File.Delete(iniFile.Path);
                return;
            }

            if (string.IsNullOrWhiteSpace(AutoLogin)) iniFile.DeleteKey("Auto-Login"); else iniFile.Write("Auto-Login", AutoLogin);
            if (string.IsNullOrWhiteSpace(AutoUpdate)) iniFile.DeleteKey("Auto-Update"); else iniFile.Write("Auto-Update", AutoUpdate);
            if (string.IsNullOrWhiteSpace(AutoOffers)) iniFile.DeleteKey("Auto-Offers"); else iniFile.Write("Auto-Offers", AutoOffers);
            if (string.IsNullOrWhiteSpace(AutoNews)) iniFile.DeleteKey("Auto-News"); else iniFile.Write("Auto-News", AutoNews);
        }
    }
}