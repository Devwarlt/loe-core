using LoESoft.Launcher.Misc;
using System.IO;

namespace LoESoft.Launcher
{
    public class Account
    {
        public static Account UserAccount { get; set; }
        public string LoginToken { get; set; } // valid for a few days at most if we want to refresh and update the token

        public static Account LoadAccount()
        {
            UserAccount = new Account();

            var iniFile = new IniFile("config.ini");
            if (!File.Exists(iniFile.Path))
            {
                File.Create(iniFile.Path).Dispose();
                return UserAccount;
            }

            UserAccount.LoginToken = iniFile.Read("Token");
            return UserAccount;
        }

        public void SaveAccount()
        {
            var iniFile = new IniFile("config.ini");
            if (UserAccount == null) // no longer needed
            {
                File.Delete(iniFile.Path);
                return;
            }

            if (string.IsNullOrWhiteSpace(LoginToken))
                iniFile.DeleteKey("Token");
            else
                iniFile.Write("Token", LoginToken);
        }

        public void Invalidate()
        {
            LoginToken = null;
            SaveAccount();
        }
    }
}
