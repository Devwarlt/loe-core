using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace LoESoft.Client.Assets
{
    public static class XmlReader
    {
        public static Dictionary<ushort, XElement> ObjectXmlDictionary { get; private set; }
        public static Dictionary<ushort, XElement> GroundXmlDictionary { get; private set; }
        public static Dictionary<ushort, XElement> PlayerXmlDictionary { get; private set; }
        public static Dictionary<ushort, XElement> ItemXmlDictionary { get; private set; }

        static XmlReader()
        {

        }

        public static void Load(ContentManager contentManager)
        {
            string path = $"{contentManager.RootDirectory}/Xmls_Asset/";
            Console.WriteLine(contentManager.RootDirectory);
        }
    }
}
