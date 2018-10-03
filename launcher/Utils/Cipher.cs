using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.OpenSsl;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Xml.Serialization;

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
            using (var rsa = new RSACryptoServiceProvider((int)RSAKeySize, new CspParameters() { KeyContainerName = LoESoftHash }))
                return HttpUtility.UrlEncode(Convert.ToBase64String(rsa.Encrypt(Encoding.UTF8.GetBytes(plainText), false)));
        }

        public static void GenerateNewRSAKeys(KeySize keySize)
        {
            var csp = new RSACryptoServiceProvider((int)keySize);
            var prik = csp.ExportParameters(true);
            var pubk = csp.ExportParameters(false);
            string privateKey, publicKey;

            var priksw = new StringWriter();
            var prikxs = new XmlSerializer(typeof(RSAParameters));
            prikxs.Serialize(priksw, prik);
            privateKey = priksw.ToString();

            var pubsw = new StringWriter();
            var pubxs = new XmlSerializer(typeof(RSAParameters));
            pubxs.Serialize(pubsw, pubk);
            publicKey = pubsw.ToString();

            GameLauncher.Warn($"Public Key:\n{publicKey}");
            GameLauncher.Warn($"Private Key:\n{privateKey}");
        }
    }
}
