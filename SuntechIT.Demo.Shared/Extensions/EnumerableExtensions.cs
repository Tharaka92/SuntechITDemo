using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuntechIT.Demo.Shared.Extensions
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (T item in list)
            {
                action(item);
            }
        }

        public static void ForEach<T>(this IEnumerable<T> list, Action<T, int> action)
        {
            int num = 0;
            foreach (T item in list)
            {
                action(item, num);
                num++;
            }
        }

        public static T AddAndReturn<T>(this ICollection<T> list, T value)
        {
            list.Add(value);
            return value;
        }

        public static IEnumerable<TSource> WhereIf<TSource>(this IEnumerable<TSource> source, bool shouldFilter, Func<TSource, bool> predicate)
        {
            if (shouldFilter)
            {
                return source.Where(predicate);
            }

            return source;
        }

        public static string JoinString(this IEnumerable<string> source, string separator)
        {
            return string.Join(separator, source);
        }

        public static bool IsNotNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source?.Any() ?? false;
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return !source.IsNotNullOrEmpty();
        }

        public static IEnumerable<T> RepeatFor<T>(this int count, Func<T> predicate)
        {
            return from x in Enumerable.Range(0, count)
                   select predicate();
        }
    }
}
