using System.Collections.Generic;

namespace Algorithms
{
    public static class Statistics
    {
        public static T Mode<T>(this IEnumerable<T> selection)
        {
            var occurrences = new Dictionary<T, int>();
            foreach (T item in selection)
            {
                if (occurrences.ContainsKey(item)) occurrences[item]++;
                else occurrences[item] = 1;
            }

            var enumerator = selection.GetEnumerator();
            enumerator.MoveNext();
            T max = enumerator.Current;
            while (enumerator.MoveNext())
                if (occurrences[max] < occurrences[enumerator.Current])
                    max = enumerator.Current;

            return max;
        }
    }
}
