using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace LoESoft.Client.Core.Utils
{
    public partial class Cipher
    {
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