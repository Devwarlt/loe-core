using LoESoft.Server.Assets.Xml;
using static LoESoft.Server.Assets.Xml.Structure.XmlContent;

namespace LoESoft.Server.Core.World.Map.Structure
{
    public class ChunkObject
    {
        public ContentType ContentType { get; set; }
        public IXmlContent XmlContent { get; set; }
    }
}