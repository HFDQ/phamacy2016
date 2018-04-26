using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BugsBox.Pharmacy.BusinessHandlers
{
    public class SearialiserHelper<T> where T : new()
    {
        #region 序列化至硬盘
        /// <summary>
        /// 序列化至硬盘
        /// </summary>
        public static Func<T, string, bool> SerializeObjToFile = (r, path) =>
        {
            try
            {
                using (Stream stream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                {
                    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    bf.Serialize(stream, r);
                    stream.Close();
                }
                return true;
            }
            catch (System.IO.IOException ex)
            {
                return false;
            }
        };
        #endregion
        #region 从硬盘文件反序列化至对象
        /// <summary>
        /// 从硬盘文件反序列化至对象
        /// </summary>
        public static Func<string, T> DeSerializeFileToObj = (file) =>
        {
            try
            {
                T t = default(T);

                if (!File.Exists(file))
                {
                    t = new T();
                }
                else
                {
                    Stream stream = File.OpenRead(file);
                    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    t = (T)bf.Deserialize(stream);
                    stream.Close();
                    stream.Dispose();
                }
                return t;
            }
            catch (IOException ex)
            {
                return default(T);
            }
        };
        #endregion
    }

    


}
