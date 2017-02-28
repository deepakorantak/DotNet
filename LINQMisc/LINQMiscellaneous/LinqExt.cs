using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQMiscellaneous
{
    public static class LinqExt
    {
        public static TimeSpan Sum(this IEnumerable<TimeSpan> timeseries)
        {
            var result = TimeSpan.Zero;
            foreach (var item in timeseries)
            {
                   result += item; 
            }

            return result;
        }

        public static string Join(this IEnumerable<string> series, string seperator)
        {
            return String.Join(seperator, series);
        }

        public static IEnumerable<KeyValuePair<TKey,int>> CountBy<TSource,TKey>(this IEnumerable<TSource> series,Func<TSource,TKey> selector)
        {
            
            var resList = new Dictionary<TKey,int>(); 
            foreach (var item in series)
            {
                var key = selector(item);
                if(resList.ContainsKey(key))
                {
                    resList[key]++;
                }
                else
                {
                    resList[key] = 1;
                }                
            }

            return resList;

        }

    }
}
