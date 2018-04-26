using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BugsBox.Application.Core
{
    public static class KnownTypeHelper
    {
        private static readonly List<Type> KnownTypes = new List<Type>();

        static KnownTypeHelper()
        {
            XsSection xsSection = XsSection.GetSection();
            if (null != xsSection)
            {
                foreach (StringElement include in xsSection.Includes)
                {
                    foreach (Type type in Assembly.Load(include.Assembly).GetTypes())
                    {
                        if (type.IsDefined(typeof(DataContractAttribute), true))
                        {
                            KnownTypes.Add(type);
                            KnownTypes.Add(type.MakeArrayType());
                        }
                    }
                }
                KnownTypes.Add(typeof(Guid).MakeArrayType());
                KnownTypes.Add(typeof(string).MakeArrayType());
                KnownTypes.Add(typeof(ArrayList));
                KnownTypes.Add(typeof(Stream));
            }
        }

        /// <summary>
        /// 注册WCF所要使用到的数据合约。
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetKnownTypes(ICustomAttributeProvider provider)
        {
            return KnownTypes;
        }
    }
}
