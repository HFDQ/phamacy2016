using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace System
{
    /// <summary>
    /// 实体类相关属性信息获取
    /// </summary>
    public static class EntityExtensions
    {
        private static Type descriptionType = typeof (DescriptionAttribute);
        private static Type displayType = typeof(DisplayAttribute); 

        static Dictionary<Type,string> DescriptionCache=new Dictionary<Type, string>();
        static Dictionary<string, string> DisplayCache = new Dictionary<string, string>();

        /// <summary>
        /// 获取T类型的DescriptionAttribute的Description值
        /// </summary>
        /// <typeparam name="T">某类型</typeparam>
        /// <returns></returns>
         public static string GetDescription<T>()
         {
             return GetDescription(typeof (T));
         }

        /// <summary>
         /// 获取type类型的DescriptionAttribute的Description值
        /// </summary>
         /// <param name="type">type</param>
         /// <returns>Description</returns>
        public static string GetDescription(Type type)
        {
          
            if(type!=null)
            {
                lock (DescriptionCache)
                {
                    if (DescriptionCache.ContainsKey(type))
                       return DescriptionCache[type];
                }
                var description =
                    type.GetCustomAttributes(false).FirstOrDefault(ca => ca.GetType() == descriptionType) as
                    DescriptionAttribute;
                if (description == null) return string.Empty;
                string descriptionString = string.IsNullOrWhiteSpace(description.Description)
                                         ? type.Name
                                         : description.Description;
                lock (DescriptionCache)
                {
                    DescriptionCache[type] = descriptionString;
                }
                return descriptionString;
            }
            return string.Empty;
        }

        /// <summary>
        /// 获取T类型的propertyName的DisplayAttribute的Name值
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="propertyName">属性名</param>
        /// <returns>Name</returns>
        public static string GetDisplay<T>(string propertyName)
        {
            return GetDisplay(typeof(T), propertyName);
        }

       /// <summary>
        /// 获取type类型的propertyName的DisplayAttribute的Name值
       /// </summary>
        /// <param name="type">类型</param>
        /// <param name="propertyName">属性名</param>
       /// <returns></returns>
       public static string GetDisplay(Type type,string propertyName)
       {
           string cacheKey = type.FullName + propertyName;
           if (type != null && !string.IsNullOrWhiteSpace(propertyName))
           {
               lock (DescriptionCache)
               {
                   if (DisplayCache.ContainsKey(cacheKey))
                       return DisplayCache[cacheKey];
               }
               var perpertyInfo = type.GetProperties()
                                      .FirstOrDefault(p => p.Name == propertyName);
               if (perpertyInfo != null)
               {
                   var display = perpertyInfo.GetCustomAttributes(false)
                                             .FirstOrDefault(ca => ca.GetType()== displayType) as DisplayAttribute;
                   if (display != null)
                   {
                       string displayString = string.IsNullOrWhiteSpace(display.Name) ? string.Empty : display.Name;
                       lock (DisplayCache)
                       {
                           DisplayCache[cacheKey] = displayString;
                       }
                       return displayString;
                   }
               }
           }
           return string.Empty;
       }
    }
}
