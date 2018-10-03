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

namespace LoESoft.WebServer.Core.Utils
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

        public static string Decrypt(string plainText)
        {
            using (var rsa = new RSACryptoServiceProvider((int)RSAKeySize, new CspParameters() { KeyContainerName = LoESoftHash }))
                return Encoding.UTF8.GetString(rsa.Decrypt(Convert.FromBase64String(plainText), false));
        }

        private static RSAParameters DeserializeRSAFromString(string key)
        {
            using (var rdr = new StringReader(key))
                return (RSAParameters)(new XmlSerializer(typeof(RSAParameters))).Deserialize(rdr);
        }

        public static string Encode(string value)
        {
            string hash = string.Empty;

            foreach (byte theByte in new HMACSHA512().ComputeHash(Encoding.ASCII.GetBytes(value + LoESoftHash), 0, Encoding.ASCII.GetByteCount(value + LoESoftHash)))
                hash += theByte.ToString("x2");

            return hash;
        }
    }
}
