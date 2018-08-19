using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Linq;
using System.Xml.XPath;
using LoESoft.Client.Properties;

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

            ProcessXmls(XElement.Parse(Resources.Players));
            
            Console.WriteLine("Xmls Loaded!");
        }

        private static void ProcessXmls(XElement root)
        {
            foreach (var i in root.XPathSelectElements("//Object"))
            {
                var type = (ushort)Int32.Parse(i.Attribute("type").Value.Substring(2), NumberStyles.HexNumber);

                XmlsDictionary.Add(type, i);
            }
        }
    }
}
