using System.IO;

namespace LoESoft.Dlls.Database
{
    public partial class LoEDb
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

        public void CreateSubDirectory(string subfolder)
        {
            var subdir = Path.Combine(MainDir, $"/{BaseDir}/{subfolder}/");

            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
                Logger($"Directory '{subdir}' has been created!");
            }
        }
    }
}
