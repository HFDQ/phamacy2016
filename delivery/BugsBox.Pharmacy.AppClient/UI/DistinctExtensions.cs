using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugsBox.Pharmacy.AppClient.UI
{
    /// <summary>
    /// distinct扩展，对任意类型的集合执行任意字段distinct
    /// 调用范例：ListT.Disinct(r=>r.XXX)
    /// </summary>
    public static class DistinctExtensions
    {
        public static IEnumerable<T> Distinct<T, V>(this IEnumerable<T> source, Func<T, V> keySelector)
        {
            return source.Distinct(new CommonEqualityComparer<T, V>(keySelector));
        }

    }
}
