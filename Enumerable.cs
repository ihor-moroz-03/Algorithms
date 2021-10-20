using System;
using System.Collections.Generic;

namespace Algorithms
{
    public static class Enumerable
    {
        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            foreach (TSource item in source)
                yield return selector(item);
        }
    }
}
