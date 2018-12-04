using System.Xml.Linq;

namespace LoESoft.AssetsManager.Core.Assets.Structure
{
    public class ItemsContent : XmlContent
    {
        public ItemsContent()
        {
        }

        public ItemsContent(XElement elem) : base(elem)
        {
        }
    }
}