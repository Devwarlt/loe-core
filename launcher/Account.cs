using LoESoft.Launcher.MIsc;
using System.IO;

namespace LoESoft.Launcher
{
    public class Account
    {
        public static Account UserAccount { get; set; }
        public string LoginToken { get; set; } // valid for a few days at most if we want to refresh and update the token

        public static void LoadAccount()
        {
            UserAccount = new Account();

            var iniFile = new IniFile("config.ini");
            if (!File.Exists(iniFile.Path))
            {
                File.Create(iniFile.Path).Dispose();
                return;
            }
            UserAccount.LoginToken = iniFile.Read("Token");
        }

        public void SaveAccount()
        {
            var iniFile = new IniFile("config.ini");
            if(UserAccount == null)
            {
                File.Delete(iniFile.Path);
                return;
            }

            if (string.IsNullOrWhiteSpace(LoginToken))
                iniFile.DeleteKey("Token");
            else
                iniFile.Write("Token", LoginToken);
        }
    }
}
