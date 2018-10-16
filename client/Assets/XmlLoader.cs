using System;
using System.Xml.Linq;

namespace LoESoft.Client.Assets
{
    public static class XmlLoader
    {
        public static XElement LoadAsset(string file)
        {
            var type = typeof(XmlLoader);

            using (var stream = typeof(XmlLoader).Assembly.GetManifestResourceStream($"{type.Namespace}.Embeds.{file}.xml"))
                if (stream != null)
                    return XElement.Load(stream);

            throw new ArgumentException("XmlFile not found", $"{type.Namespace}.Embeds.{file}.xml");
        }
    }
}