using LoESoft.Dlls.MapEditor;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Linq;

namespace LoESoft.Dlls.Utils
{
    public partial class Util
    {
        public List<XElement> GetEmbeddedXmls(string @namespace)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var xmls = new List<XElement>();

            foreach (var i in assembly.GetManifestResourceNames())
                if (i.Contains(@namespace))
                    using (var stream = assembly.GetManifestResourceStream(i))
                        if (stream != null)
                            xmls.Add(XElement.Load(stream));

            Logger($"Loaded {xmls.Count} embedded XML file{(xmls.Count > 1 ? "s" : "")}.");

            return xmls;
        }

        public List<KeyValuePair<bool, byte[]>> GetEmbeddedMaps<Map>(string @namespace, string compressedFormat = LoEMapper<Map>.FileFormatCompressed, string nonCompressedFormat = LoEMapper<Map>.FileFormatNonCompressed)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var maps = new List<KeyValuePair<bool, byte[]>>();

            foreach (var i in assembly.GetManifestResourceNames())
                if (i.Contains(@namespace) && (i.Contains($".{compressedFormat}") || i.Contains($".{nonCompressedFormat}")))
                    using (var stream = assembly.GetManifestResourceStream(i))
                        if (stream != null)
                            using (var memorystream = new MemoryStream())
                            {
                                stream.CopyTo(memorystream);

                                if (i.Contains($".{compressedFormat}"))
                                    maps.Add(new KeyValuePair<bool, byte[]>(true, memorystream.ToArray()));
                                else
                                    maps.Add(new KeyValuePair<bool, byte[]>(false, memorystream.ToArray()));
                            }

            Logger($"Loaded {maps.Count} embedded Map file{(maps.Count > 1 ? "s" : "")}.");

            return maps;
        }
    }
}