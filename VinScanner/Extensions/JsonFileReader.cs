using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;

namespace VinScanner.Extensions
{
    public static class JsonFileReader
    {
        public static T ReadFile<T> (string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var fullFilePath = $"{assembly}/Content/{fileName}.json";
            using (var stream = new StreamReader(fullFilePath))
            {
                if (stream == null)
                    throw new ArgumentException("Cound not find the resource.");

                string jsonFile = stream.ReadToEnd();
                T items = JsonConvert.DeserializeObject<T>(jsonFile);
                return items;
            }
        }
    }
}
