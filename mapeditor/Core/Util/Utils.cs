using LoESoft.MapEditor.Core.Layer;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using System.Reflection;

namespace LoESoft.MapEditor.Core.Util
{
    public static class Utils
    {
        public static Texture2D LoadEmbeddedTexture(string file)
        {
            var assembly = Assembly.GetExecutingAssembly();
            Texture2D texture2d = null;

            foreach (var name in assembly.GetManifestResourceNames())
                if (name.Contains(file))
                {
                    using (var stream = assembly.GetManifestResourceStream(name))
                        if (stream != null)
                            texture2d = Texture2D.FromStream(MapEditor.GraphicsDeviceManager.GraphicsDevice, stream);
                    break;
                }

            return texture2d;
        }

        public static string Save(this Map map)
            => JsonConvert.SerializeObject(new MapData()
            {
                Size = map.Size,
                Layers = map.Layers
            });

        public static void Load(this Map map, string mapName, string content)
        {
            App.Info("Loading new map...");

            var mapdata = JsonConvert.DeserializeObject<MapData>(content);

            MapEditor.Map = new Map(mapdata.Size);
            MapEditor.Map.Layers = map.Layers;
            MapEditor.CurrentLayer = MapLayer.UNDERGROUND;
            MapEditor.CurrentIndex = 0;
            MapEditor.DrawOffset = Vector2.Zero;
            MapEditor.ActualMapName = mapName;
            MapEditor.ActualMapSize = mapdata.Size;
            MapEditor.FormattedMapName = $"(Size: {(int)MapEditor.ActualMapSize} x {(int)MapEditor.ActualMapSize}) Map: {MapEditor.ActualMapName}";

            MapEditor.LoadTileSets(false);

            App.Info("Loading new map... OK!");
        }
    }
}