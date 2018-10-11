﻿using System;
using System.Security.Cryptography;
using System.Text;

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
            try
            {
                using (var rsa = new RSACryptoServiceProvider((int)RSAKeySize, new CspParameters() { KeyContainerName = LoESoftHash }))
                    return Encoding.UTF8.GetString(rsa.Decrypt(Convert.FromBase64String(plainText), false));
            }
            catch { return plainText; }
        }

        public static string Encode(string value)
        {
            string hash = string.Empty;

            foreach (byte theByte in new SHA512Managed().ComputeHash(Encoding.UTF8.GetBytes(value + LoESoftHash), 0, Encoding.UTF8.GetByteCount(value + LoESoftHash)))
                hash += theByte.ToString("x2");

            return hash;
        }
    }
}