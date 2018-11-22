using System.IO;
using System.IO.Compression;
using System.Text;

namespace LoESoft.Server.Utils
{
    public class WorldTime
    {
        public int TickCount { get; set; }
        public int TotalElapsedMs { get; set; }
    }
    public class Zipper
    {
        public Zipper() { }

        public void CopyTo(Stream src, Stream dest)
        {
            byte[] bytes = new byte[4096];

            int cnt;

            while ((cnt = src.Read(bytes, 0, bytes.Length)) != 0)
            {
                dest.Write(bytes, 0, cnt);
            }
        }

        public byte[] Zip(string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);

            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(mso, CompressionMode.Compress))
                    CopyTo(msi, gs);

                return mso.ToArray();
            }
        }

        public byte[] Unzip(byte[] bytes)
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