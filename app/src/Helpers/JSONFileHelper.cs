using System;
using System.IO;
using Newtonsoft.Json;

namespace ConfigManager.Helpers
{
    public class JSONFileHelper
    {
        public dynamic ReadJSONFromPath(string path, Type type)
        {
            path = AdjustPathSafely(path);

            using(var reader = File.OpenText(path))
            {
                var serializer = new JsonSerializer();

                return serializer.Deserialize(reader, type);
            }
        }

        public void WriteJSONToFile(dynamic data, string path)
        {
            path = AdjustPathSafely(path);
            
            using(var fileStream = File.Open(path, FileMode.OpenOrCreate))
            using(var streamWriter = new StreamWriter(fileStream))
            using(var jsonWriter = new JsonTextWriter(streamWriter))
            {
                jsonWriter.Formatting = Formatting.Indented;

                var serializer = new JsonSerializer();
                serializer.Serialize(jsonWriter, data);
            }
        }

        private string AdjustPathSafely(string path)
        {
            if(!path.Contains(".json"))
                path = path + ".json";
            
            return path;
        }
    }
}