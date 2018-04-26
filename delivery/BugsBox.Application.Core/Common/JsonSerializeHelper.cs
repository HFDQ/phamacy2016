using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace System
{
    public static class JsonSerializeHelper
    {
        public static T DeSerializeJson<T>(string jsonFile)
        {
            if (string.IsNullOrWhiteSpace(jsonFile)||!File.Exists(jsonFile))
            {
                return default(T);
            }
            StreamReader reader = new StreamReader(jsonFile);
            string jsonString = reader.ReadToEnd(); 
            reader.Dispose();;
            if(string.IsNullOrWhiteSpace(jsonString))
                return default(T);
            return jsonString.ToObject<T>();
        }

        public static bool SerializeJson(this object value, string jsonFile)
        {
            if (value ==null) return false;
            if (string.IsNullOrWhiteSpace(jsonFile) || File.Exists(jsonFile))
            {
                return false;
            }
            string jsonString = value.ToJson();
            FileStream fs = new FileStream(jsonFile, FileMode.CreateNew, FileAccess.ReadWrite);
            StreamWriter writer = new StreamWriter(fs);
            writer.WriteLine(jsonString);
            writer.Dispose();
            fs.Dispose(); 
            return true; 
        }
    }
}
