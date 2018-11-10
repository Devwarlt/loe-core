using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;

namespace LoESoft.Server.Assets.Xml
{
    public static class XmlLoader
    {
        public static List<XElement> GetEmbeddedGameAssets()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var xmls = new List<XElement>();

            foreach (var i in assembly.GetManifestResourceNames())
            {
                if (i.Contains($"{typeof(XmlLoader).Namespace}.Embeds."))
                    using (var stream = assembly.GetManifestResourceStream(i))
                        if (stream != null)
                            xmls.Add(XElement.Load(stream));
            }

            App.Info($"Loaded {xmls.Count} embedded XML file{(xmls.Count > 1 ? "s" : "")}.");

            return xmls;
        }
    }
}