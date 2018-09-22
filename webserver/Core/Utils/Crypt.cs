using System.Security.Cryptography;
using System.Text;

namespace LoESoft.WebServer.Core.Utils
{
    public class Crypt
    {
        public static string LoESoftHash => "_103s0f7 g4m3s_";

        public static string Encode(string value)
        {
            string hash = string.Empty;

            foreach (byte theByte in new HMACSHA512().ComputeHash(Encoding.ASCII.GetBytes(value + LoESoftHash), 0, Encoding.ASCII.GetByteCount(value + LoESoftHash)))
                hash += theByte.ToString("x2");

            return hash;
        }
    }
}
