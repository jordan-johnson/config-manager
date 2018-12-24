using System;
using ConfigManager.Helpers;

namespace ConfigManager
{
    public class Configuration<T>
    {
        private JSONFileHelper _json;
        private string _filePath;
        
        public T Data { get; private set; }

        /// <summary>Path to create configuration file. Does NOT need extension.</summary>
        public Configuration(string path = "config")
        {
            _filePath = path;

            _json = new JSONFileHelper();
        }

        /// <summary>Reads JSON from file set by constructor</summary>
        public void ReadJSON()
        {
            ReadJSON(_filePath);
        }

        /// <summary>Reads JSON from file</summary>
        public void ReadJSON(string path)
        {
            Data = (T)_json.ReadJSONFromPath(path, typeof(T));
        }

        /// <summary>Writes JSON to file using file set by constructor</summary>
        public void WriteJSON(dynamic data)
        {
            WriteJSON(data, _filePath);
        }

        /// <summary>Writes JSON to file</summary>
        public void WriteJSON(dynamic data, string path)
        {
            _json.WriteJSONToFile(data, path);
        }
    }
}