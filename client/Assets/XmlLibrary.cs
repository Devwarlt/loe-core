using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LoESoft.Client.Assets
{
    public static class XmlLibrary
    {
        public class XmlContent
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public string FileName { get; set; }
            public Tuple<int, int> ImageIndex { get; set; }
        }

        public static Dictionary<string, XmlContent> Assets = new Dictionary<string, XmlContent>();

        public static void Init()
        {
            //Load all xml files
        }

        private static void LoadContent(string name)
        {
            var xmlFile = XmlLoader.LoadAsset(name);

            var xmlList = new List<XElement>();
            
            //process through the xml file...
        }
    }
}
