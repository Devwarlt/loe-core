﻿using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace LoESoft.Server.utils
{
    public class IO
    {
        public static T Import<T>(string path, string name) =>
            JsonConvert.DeserializeObject<T>(File.ReadAllText($"{path}{name}.json", Encoding.UTF8));

        public static void Export<T>(T t, string path, string name) =>
            File.WriteAllText($"{path}{name}.json", JsonConvert.SerializeObject(t), Encoding.UTF8);
    }
}