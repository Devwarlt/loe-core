using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace LoESoft.Launcher.Misc
{
    public class IniFile
    {
        public string Path { get; set; }
        public string Exe { get; set; }

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        public static extern long WritePrivateProfileString(string section, string key, string value, string filePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        public static extern int GetPrivateProfileString(string section, string key, string dfault, StringBuilder retValue, int size, string filePath);

        public IniFile(string iniPath = null)
        {
            Exe = Assembly.GetExecutingAssembly().GetName().Name;
            Path = new FileInfo(iniPath ?? Exe + ".ini").FullName.ToString();
        }

        public string Read(string key, string section = null)
        {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(section ?? Exe, key, "", RetVal, 255, Path);
            return RetVal.ToString();
        }

        public void Write(string key, string value, string section = null) => WritePrivateProfileString(section ?? Exe, key, value, Path);

        public void DeleteKey(string key, string section = null) => Write(key, null, section ?? Exe);

        public void DeleteSection(string section = null) => Write(null, null, section ?? Exe);

        public bool KeyExists(string key, string section = null) => Read(key, section).Length > 0;
    }
}
