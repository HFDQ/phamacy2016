using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugsBox.Pharmacy.Business.Models
{
    /// <summary>
    /// List中泛型比较器，
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="K"></typeparam>
    public class GenericCommonClass<T> where T:System.Collections.Generic.IEqualityComparer<T>
    {
        public static bool CompareClass<T>(T X,T Y)
        {
            
            return false;
        }
    }

}
