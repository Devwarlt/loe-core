using System.IO;
using System.IO.Compression;
using System.Text;

namespace LoESoft.Dlls.GZip
{
    public partial class GZipCompression
    {
        public static byte[] Zip(string data)
        {
            var bytes = Encoding.UTF8.GetBytes(data);

            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(mso, CompressionMode.Compress))
                    CopyTo(msi, gs);

                return mso.ToArray();
            }
        }

        public static byte[] UnZip(byte[] bytes)
        {
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                    CopyTo(gs, mso);

                return mso.ToArray();
            }
        }
    }
}