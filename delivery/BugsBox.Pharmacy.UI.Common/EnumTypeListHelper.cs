using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugsBox.Pharmacy.UI.Common
{
    public class EnumTypeListHelper
    {
        /// <summary>
        /// 传递一个Enum，转换为EnumTypeList集合。
        /// 调用范例：ConverEnumToList(typeof(enum))
        /// </summary>
        /// <param name="t">typeof(TEnum)</param>
        public static IEnumerable<EnumTypeList> ConverEnumToList(Type t)
        {
            List<EnumTypeList> List = new List<EnumTypeList>();
            var c = Enum.GetNames(t);
            for (int i = 0; i < c.Length; i++)
            {
                List.Add(new EnumTypeList { Id = i, Name = c[i] });
            }
            return List;
        }
    }

    public class EnumTypeList
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
