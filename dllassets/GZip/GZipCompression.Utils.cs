using System.IO;

namespace LoESoft.Dlls.GZip
{
    public partial class GZipCompression
    {
        public static void CopyTo(Stream source, Stream target)
        {
            var bytes = new byte[4096];

            int cnt;

            while ((cnt = source.Read(bytes, 0, bytes.Length)) != 0)
                target.Write(bytes, 0, cnt);
        }
    }
}
