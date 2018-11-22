using System.IO;

namespace LoESoft.Dlls.MapEditor
{
    public partial class LoEMapper<Map>
    {
        public void CreateMainDirectory()
        {
            if (!Directory.Exists(MainDir))
            {
                Directory.CreateDirectory(MainDir);
                Logger($"Directory '{MainDir}' has been created!");
            }
        }
    }
}
