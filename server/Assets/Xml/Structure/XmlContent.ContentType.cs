namespace LoESoft.Server.Assets.Xml.Structure
{
    public partial class XmlContent : IXmlContent
    {
        public enum ContentType : int
        {
            Objects = 0,
            Items = 1,
            Tiles = 2
        }
    }
}