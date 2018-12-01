using LoESoft.Dlls.GZip;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

namespace LoESoft.Dlls.Database
{
    public partial class LoEDb
    {
        public void Save<T>(string subfolder, string filename, T data)
        {
            if (data == null)
                Logger($"Content data is empty and being ignored.");
            else
            {
                try
                {
                    var filepath = Path.Combine(GetSubDirectory(subfolder), $"{filename}.{Format}");
                    var content = JsonConvert.SerializeObject(data);

                    if (EnableCompression)
                        File.WriteAllBytes(filepath, GZipCompression.Zip(content));
                    else
                        File.WriteAllText(filepath, content);

                    Logger($"[SubDir: '{subfolder}'] Saved to path: '{filepath}'");
                }
                catch (Exception e) { Logger($"(SaveException) An error occurred along save method:\n{e}"); }
            }
        }

        public T Load<T>(string subfolder, string filename)
        {
            var filepath = Path.Combine(GetSubDirectory(subfolder), $"{filename}.{Format}");

            object data = null;

            try
            {
                data = EnableCompression ? JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(GZipCompression.UnZip(File.ReadAllBytes(filepath))))
                    : JsonConvert.DeserializeObject<T>(File.ReadAllText(filepath));

                Logger($"[SubDir: '{subfolder}'] Loaded from path: '{filepath}'");
            }
            catch (Exception e)
            {
                Logger($"(LoadException) An error occurred along load method:" +
                    $"\n- File: '{filepath}'" +
                    $"\n- Error: {e}");
            }

            return (T)data;
        }
    }
}