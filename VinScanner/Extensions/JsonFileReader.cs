using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;

namespace VinScanner.Extensions
{
    public static class JsonFileReader
    {
        public static T ReadFile<T>(string fileName)
        {
            var fullFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Content", $"{fileName}.json");

            using (StreamReader reader = new StreamReader(fullFilePath))
            {
                string jsonFile = reader.ReadToEnd();
                T items = JsonConvert.DeserializeObject<T>(jsonFile);
                return items;
            }
        }
    }
}
