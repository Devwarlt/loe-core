using LoESoft.MapEditor.Core.Layer;
using System.Collections.Generic;

namespace LoESoft.MapEditor
{
    public class MapData
    {
        public MapSize Size { get; set; }
        public List<Layer> Layers { get; set; }
    }
}