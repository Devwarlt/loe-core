using System.IO;
using System.Linq;

namespace LoESoft.Dlls.Database
{
    public partial class LoEDb
    {
        public void CreateMainDirectory()
        {
            if (!Directory.Exists(BaseDir))
            {
                Directory.CreateDirectory(BaseDir);

                Logger($"Directory '{BaseDir}' has been created!");
            }
        }

        public void CreateSubDirectory(string subfolder)
        {
            var subdir = Path.Combine(BaseDir, subfolder);

            SubFolders.Add(subdir);

            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);

                Logger($"Directory '{subdir}' has been created!");
            }
        }

        public string GetSubDirectory(string subfolder) => SubFolders.FirstOrDefault(sf => sf.Contains(subfolder));
    }
}