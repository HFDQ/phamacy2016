using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace BugsBox.Pharmacy.UI.Common.Helper
{
    public static class EnumHelper<T>
    {
        public static IList<T> GetValues(Enum value)
        {
            var enumValues = new List<T>();

            foreach (FieldInfo fi in value.GetType().GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                enumValues.Add((T)Enum.Parse(value.GetType(), fi.Name, false));
            }
            return enumValues;
        }

        public static T Parse(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static List<ListItem> GetMapKeyValues()
        {
            List<ListItem> list = new List<ListItem>();
            var fieldInfo = typeof(T).GetFields(BindingFlags.Static | BindingFlags.Public);
            foreach (FieldInfo f in fieldInfo)
            {
                int i = Convert.ToInt32(Enum.Parse(typeof(T), f.Name));
                var descriptionAttributes =f.GetCustomAttributes(
                typeof(DisplayAttribute), false) as DisplayAttribute[];

                if (descriptionAttributes != null && descriptionAttributes.Length > 0)
                {
                    list.Add(new ListItem(i.ToString(), descriptionAttributes[0].Name));
                }
                else
                {
                    list.Add(new ListItem(i.ToString(), f.Name));
                }
            }
            return list;
        }

        public static IList<string> GetNames(Enum value)
        {
            return value.GetType().GetFields(BindingFlags.Static | BindingFlags.Public).Select(fi => fi.Name).ToList();
        }

        public static IList<string> GetDisplayValues(Enum value)
        {
            return GetNames(value).Select(obj => GetDisplayValue(Parse(obj))).ToList();
        }

        public static string GetDisplayValue(T value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            var descriptionAttributes = fieldInfo.GetCustomAttributes(
                typeof(DisplayAttribute), false) as DisplayAttribute[];

            if (descriptionAttributes == null) return string.Empty;
            return (descriptionAttributes.Length > 0) ? descriptionAttributes[0].Name : value.ToString();
        }

        public static string GetDisplayDescription(T value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            var descriptionAttributes = fieldInfo.GetCustomAttributes(
                typeof(DisplayAttribute), false) as DisplayAttribute[];

            if (descriptionAttributes == null) return string.Empty;
            return (descriptionAttributes.Length > 0) ? descriptionAttributes[0].Description : value.ToString();
        }
    }
}
