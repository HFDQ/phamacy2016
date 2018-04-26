using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugsBox.Pharmacy.AppClient.UI
{
    public class RequiredFieldsCheck<T>
    {
        private T _t;
        public RequiredFieldsCheck(T t)
        {
            this._t = t;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string CheckRequiredFields(T t)
        {
            string b = string.Empty;
            var c = t.GetType().GetProperties();
            foreach (var i in c)
            {
                var p = i.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.RequiredAttribute), false).FirstOrDefault();
                if (p == null) continue;
                var AttrDisPlayName = i.GetCustomAttributes(typeof(System.ComponentModel.DisplayNameAttribute), false);
                System.ComponentModel.DisplayNameAttribute DisPlayName = AttrDisPlayName.FirstOrDefault() as System.ComponentModel.DisplayNameAttribute;

                var v = i.GetValue(t, null);
                if (v == null || string.IsNullOrEmpty(v.ToString()))
                {
                    if (DisPlayName == null)
                    {
                        return i.Name;
                    }
                    return DisPlayName.DisplayName;
                }
            }
            return b;
        }
    }
}
