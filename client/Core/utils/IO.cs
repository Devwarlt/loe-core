using Newtonsoft.Json;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace LoESoft.Client.Core.Utils
{
    public class IO
    {
        public static T Import<T>(string path, string name) => JsonConvert.DeserializeObject<T>(File.ReadAllText($"{path}{name}.json", Encoding.UTF8));

        public static void Export<T>(T t, string path, string name) => File.WriteAllText($"{path}{name}.json", JsonConvert.SerializeObject(t), Encoding.UTF8);

        public static string ExportPacket<Packet>(Packet packet) => JsonConvert.SerializeObject(packet);
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