using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace LoESoft.Client.Assets
{
    public static class XmlReader
    {
        public static Dictionary<ushort, XElement> XmlsDictionary { get; private set; }

        static XmlReader()
        {
            XmlsDictionary = new Dictionary<ushort, XElement>();
        }

        public static void Load(ContentManager contentManager)
        {
            Console.WriteLine("Loading Xmls...");

            string path = $"{contentManager.RootDirectory}/Xmls_Folder/";

            string[] xmls = Directory.EnumerateFiles(path, "*.xml", SearchOption.AllDirectories).ToArray();

            foreach (var i in xmls)
                using (var r = File.OpenRead(i))
                    ProcessXmls(XElement.Load(r));

            Console.WriteLine("Xmls Loaded!");
        }

        private static void ProcessXmls(XElement root)
        {
            foreach (var i in root.XPathSelectElements("//Object"))
            {
                var type = (ushort)Int32.Parse(i.Attribute("type").Value.Substring(2), NumberStyles.HexNumber);

                XmlsDictionary.Add((ushort)type, i);
            }
        }
    }
}
