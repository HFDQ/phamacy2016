using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyLibs;

namespace BugsBox.Pharmacy.AppClient.UI
{
    public static class EnumToListHelper
    {
        /// <summary>
        /// 传递一个Enum，转换为EnumTypeList对象，并加入列表。
        /// 调用范例：ConverEnumToList(typeof(enum))
        /// </summary>
        /// <param name="t">typeof(TEnum)</param>
        public static List<MyLibs.EnumTypeList> ConverEnumToList(Type t)
        {
            return MyLibs.AttributeProcess.GenerateListByDisplayAttribute(t);
        }
    }

}
