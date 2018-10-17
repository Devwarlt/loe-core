using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace LoESoft.Launcher.Utils
{
    public class Cipher
    {
        public enum KeySize : int
        {
            KEY_512 = 512,
            KEY_1024 = 1024,
            KEY_2048 = 2048
        }

        public static string LoESoftHash => "_103s0f7 g4m3s_";
        public static KeySize RSAKeySize => KeySize.KEY_512;

        public static string Encrypt(string plainText)
        {
            try
            {
                using (var rsa = new RSACryptoServiceProvider((int)RSAKeySize, new CspParameters() { KeyContainerName = LoESoftHash }))
                    return HttpUtility.UrlEncode(Convert.ToBase64String(rsa.Encrypt(Encoding.UTF8.GetBytes(plainText), false)));
            }
            catch { return plainText; }
        }
    }
}
