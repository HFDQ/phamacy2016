using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.Models;
using System.Reflection;
using System.Text.RegularExpressions;

namespace BugsBox.Pharmacy.UI.Common.Helper
{
    public class Utility
    {
        public static string GetFieldName(Object value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            return fieldInfo.Name;
        }

        public static bool IsGUID(string expression)
        {
            if (expression != null)
            {
                Regex guidRegEx = new Regex(@"^(\{{0,1}([0-9a-fA-F]){8}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){12}\}{0,1})$");
                return guidRegEx.IsMatch(expression);
            }
            return false;
        }


        public static string CompareObjectProperties(object objA, object objB)
        {
            string DifferentField = "";
            
            foreach (PropertyInfo p in objA.GetType().GetProperties())
            {
                if (p.GetValue(objA, null) != p.GetValue(objB, null))
                {
                    DifferentField += p.Name + ",";
                }
            }
       
            return DifferentField;
        }

        /// <summary>
        /// 获取枚举类型的DisplayName
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string getEnumTypeDisplayName<T>( T t)
        {
            var f = typeof(T).GetField(t.ToString());
            if (f == null)
            {
                return "异常状态";
            }
            var attr = f.GetCustomAttributes(false);
            if (attr.Length > 0 && attr[0] as System.ComponentModel.DataAnnotations.DisplayAttribute != null)
            {
                return (attr[0] as System.ComponentModel.DataAnnotations.DisplayAttribute).Name;
            }
            else
            {
                return "异常状态";
            }
        }

        /// <summary>
        /// 从枚举类型获取下拉框内容
        /// </summary>
        /// <typeparam name="EnumType"></typeparam>
        /// <returns></returns>
        public static List<ListItem> CreateComboboxList<T>(bool addEmpty = false)
        {
            var list = new List<ListItem>();
            foreach (var f in typeof(T).GetFields())
            {
                var attr = f.GetCustomAttributes(false);
                if (attr.Length > 0 && attr[0] as System.ComponentModel.DataAnnotations.DisplayAttribute != null)
                {
                    var name = (attr[0] as System.ComponentModel.DataAnnotations.DisplayAttribute).Name;
                    var type = typeof(T).InvokeMember(f.Name, System.Reflection.BindingFlags.GetField, null, null, null);
                    list.Add(new ListItem(((int)type).ToString(), name));
                }
            }
           
            return list;
        }

        /// <summary>
        /// 从枚举类型获取下拉框内容
        /// </summary>
        /// <typeparam name="EnumType"></typeparam>
        /// <returns></returns>
        public static List<ListEnumItem> CreateComboboxEnumList<T>()
        {
            var list = new List<ListEnumItem>();
            foreach (var f in typeof(T).GetFields())
            {
                var attr = f.GetCustomAttributes(false);
                if (attr.Length > 0 && attr[0] as System.ComponentModel.DataAnnotations.DisplayAttribute != null)
                {
                    var name = (attr[0] as System.ComponentModel.DataAnnotations.DisplayAttribute).Name;
                    var type = typeof(T).InvokeMember(f.Name, System.Reflection.BindingFlags.GetField, null, null, null);
                    ListEnumItem enumItem = new ListEnumItem();
                    enumItem.ID = (int)type;
                    enumItem.Name = name.ToString();
                    list.Add(enumItem);
                }
            }


            return list;
        }
    }

    public class ListEnumItem
    {
         public int ID { get; set; }
         public string Name { get; set; }
     }
}
