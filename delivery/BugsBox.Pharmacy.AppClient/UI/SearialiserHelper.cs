using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BugsBox.Pharmacy.AppClient.UI
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

    #region 需序列化的电子标签类
    /// <summary>
    /// 电子标签类
    /// </summary>
    [Serializable]
    public class Ele_Lab
    {
        /// <summary>
        /// 使用的通讯串口名称
        /// </summary>
        public string PortName { get; set; }

        /// <summary>
        /// 是否启用电子标签
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// 连接是否正常
        /// </summary>
        public bool IsNormal { get; set; }

        /// <summary>
        /// 采购入库亮灯
        /// </summary>
        public byte PurchaseInInventoryLed { get; set; }

        /// <summary>
        /// 拣货亮灯
        /// </summary>
        public byte PickGoodsLed { get; set; }

        /// <summary>
        /// 测试亮灯
        /// </summary>
        public byte TestLed { get; set; }
    }

    #endregion

        
    /// <summary>
    /// 本地配置文件操作静态类
    /// </summary>
    public static class SerialFile
    {
        public static Business.Models.CommonSetupFile csf = SearialiserHelper<Business.Models.CommonSetupFile>.DeSerializeFileToObj("UserData.dat");
        public static bool SaveFile()
        {
            return SearialiserHelper<Business.Models.CommonSetupFile>.SerializeObjToFile(csf, "UserData.dat");
        }
    }


}
