using System.IO;

namespace LoESoft.Dlls.MapEditor
{
    public partial class LoEMapper<Map>
    {
        public void CreateMainDirectory()
        {
            var basedir = Path.Combine(MainDir, BaseDir);

            if (!Directory.Exists(basedir))
            {
                Directory.CreateDirectory(basedir);
                Logger($"Directory '{basedir}' has been created!");
            }
        }
    }
}