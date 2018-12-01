using System.IO;

namespace LoESoft.Dlls.MapEditor
{
    public partial class LoEMapper<Map>
    {
        public void CreateMainDirectory()
        {
            if (!Directory.Exists(BaseDir))
            {
                Directory.CreateDirectory(BaseDir);
                Logger($"Directory '{BaseDir}' has been created!");
            }
        }
    }
}